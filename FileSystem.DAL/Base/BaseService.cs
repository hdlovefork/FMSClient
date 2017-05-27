/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 14:13:04 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using FileSystem.Entity;

namespace FileSystem.DAL
{
    /// <summary>
    /// 高大尚的底层查询服务类，里面有很多神奇的方法，让你抵不住我的诱惑
    /// 如果想使用我，请叫我“爸爸”（继承我），我将帮助你拿到数据库的数据
    /// </summary>
    /// <typeparam name="T">你要返回的Entity类型（实体类）</typeparam>
    public abstract class BaseService<T> where T : BaseEntity,new()
    {
        /// <summary>
        /// 数据库连接字符串，通过app.config文件修改成你的，这样写的好处在于可以在不修改程序代码的前提下换数据库
        /// 因为是在外部操作
        /// </summary>
        private static string _conn = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        //private static string _conn = @"Data Source=DESKTOP-3L6FC49\SQLEXPRESS;Initial Catalog=FMSDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        /// <summary>
        /// 数据库操作帮助类的实例对象
        /// </summary>
        protected static DbUtility _db = new DbUtility(_conn, DbProviderType.SqlServer);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        public List<T> Find()
        {
            return Find(string.Empty);
        }

        /// <summary>
        /// 按条件查询多条数据,如果查询所有记录condition请设为string.Empty
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<T> Find(string condition)
        {
            return Find(condition, null);
        }

        public List<TEntity> Find<TEntity>(IQueryInfo q,string condition, params DbParameter[] paramList)
            where TEntity:BaseEntity,new()
        {
            string str = string.Format("SELECT {0} FROM {1}{2}", q.SelectedFields, q.TableName, string.IsNullOrWhiteSpace(condition) ? string.Empty : " WHERE " + condition);
            if (!string.IsNullOrWhiteSpace(q.SortField))//排序字段不为空时才排序
                str += string.Format(" ORDER BY {3} {4}", q.SortField, q.IsDescending ? "DESC" : "ASC");
            return this.GetList<TEntity>(str, paramList);
        }

        /// <summary>
        /// 根据条件查询多条数据-单表,如果查询所有记录condition请设为string.Empty
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public List<T> Find(string condition, params DbParameter[] paramList)
        {
            return Find<T>(QueryInfo, condition, paramList);
        }

        public List<T> Find(IQueryInfo queryInfo, string condition, params DbParameter[] paramList)
        {
            string str = string.Format("SELECT {0} FROM {1}{2}", queryInfo.SelectedFields, queryInfo.TableName, string.IsNullOrWhiteSpace(condition) ? string.Empty : " WHERE " + condition);
            if (!string.IsNullOrWhiteSpace(queryInfo.SortField))//排序字段不为空时才排序
                str += string.Format(" ORDER BY {3} {4}", queryInfo.SortField, queryInfo.IsDescending ? "DESC" : "ASC");
            return this.GetList(str, paramList);
        }

        /// <summary>
        /// 获得集合第一条数据-单表,如果查询所有记录condition请设为string.Empty
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public T FindSingle(string condition, params DbParameter[] paramList)
        {
            T local = null;
            List<T> list = this.Find(condition, paramList);
            if (list.Count > 0)
            {
                local = list[0];
            }
            return local;
        }

        /// <summary>
        /// 根据主键得到数据-单表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> FindById(int id)
        {
            string condition = string.Format("{0}={1}", QueryInfo.PrimaryKey, id);
            return Find(condition);
        }

        private int DeleteWithTransaction(string tableName, string fieldName, object fieldValue)
        {
            string sql = string.Format("DELETE FROM {0} WHERE {1} = @ID", tableName, fieldName);
            SqlParameter parameter = new SqlParameter("@ID", fieldValue);
            return _db.ExecuteNonQueryWithTransaction(sql, new SqlParameter[] { parameter });
        }

        private int DeleteWithTransaction(IQueryInfo q, string id)
        {
            int affectedRows = 0;
            if (q.Relationship.Count > 0)
            {
                //先删除关系表的记录
                foreach (var r in QueryInfo.Relationship)
                {
                    affectedRows += DeleteWithTransaction(r.TableName, r.FieldName ?? q.PrimaryKey, id);
                }
            }
            //删除主表记录
            affectedRows += DeleteWithTransaction(q.TableName, q.PrimaryKey, id);

            return affectedRows;
        }
        /// <summary>
        /// 根据主键删除数据-单表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByKey(string id)
        {
            int affectedRows = 0;
            try
            {
                _db.BeginTransaction();
                affectedRows = DeleteWithTransaction(QueryInfo, id);
                _db.CommitTransaction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _db.RollbackTransaction();
            }
            return affectedRows > 0;
        }

        public bool Delete(string condition, params DbParameter[] paramsList)
        {
            return Delete(QueryInfo.TableName, condition, paramsList);
        }

        public bool Delete(string tableName, string condition, params DbParameter[] paramsList)
        {
            if (string.IsNullOrWhiteSpace(condition))
                throw new ArgumentNullException("condition参数不能为空，该condition为删除条件");
            string sql = string.Format("DELETE FROM {0} WHERE {1}", tableName, condition);
            return _db.ExecuteNonQuery(sql, paramsList) > 0; ;
        }

        /// <summary>
        /// 插入数据，返回新的ID，失败返回-1
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(T t)
        {
            IList<DbParameter> pList;
            string sql = EntityToInsertSQL(t, out pList);
            sql += ";SELECT @@IDENTITY";
            if (pList.Count == 0) return -1;
            object o = _db.ExecuteScalar(sql, pList);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }

        public bool Update(T t)
        {
            IList<DbParameter> pList;
            string sql = EntityToUpdateSQL(t, out pList);
            if (pList.Count == 0) return false;
            return _db.ExecuteNonQuery(sql, pList) > 0;
        }

        /// <summary>
        /// 使用事务方式删除多个表的多条记录，专用于多表删除
        /// </summary>
        /// <param name="sqlList"></param>
        /// <param name="pList"></param>
        /// <returns></returns>
        public bool DeleteWithTransaction(IList<string> sqlList, IList<DbParameter[]> pList)
        {
            if (sqlList == null || pList == null || sqlList.Count == 0 || pList.Count == 0 || sqlList.Count != pList.Count)
                throw new ArgumentException("输入的参数为0或者sqlList和pList的数量不一致");
            int affectedRows = 0;
            try
            {
                _db.BeginTransaction();
                for (int i = 0; i < sqlList.Count; i++)
                {
                    _db.ExecuteNonQueryWithTransaction(sqlList[i], pList[i]);
                }
                _db.CommitTransaction();
            }
            catch
            {
                _db.RollbackTransaction();
            }
            return affectedRows > 0;
        }

        /// <summary>
        /// 使用事务的方式删除一条记录成功返回True
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool DeleteWithTransaction(T t)
        {
            return DeleteWithTransaction<T, object, object, object>(t, null, null, null, QueryInfo, null, null, null);
        }

        public bool DeleteWithTransaction<T1, T2>(T1 t1, T2 t2, IQueryInfo q1, IQueryInfo q2)
        {
            return DeleteWithTransaction<T1, T2, object, object>(t1, t2, null, null, q1, q2, null, null);
        }

        public bool DeleteWithTransaction<T1, T2, T3>(T1 t1, T2 t2, T3 t3, IQueryInfo q1, IQueryInfo q2, IQueryInfo q3)
        {
            return DeleteWithTransaction<T1, T2, T3, object>(t1, t2, t3, null, q1, q2, q3, null); ;
        }

        public bool DeleteWithTransaction<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, IQueryInfo q1, IQueryInfo q2, IQueryInfo q3, IQueryInfo q4)
        {
            IList<DbParameter> pList;
            string sql = string.Empty;
            int affectedRows = 0;
            try
            {
                _db.BeginTransaction();
                if (t1 != null && q1 != null)
                {
                    sql = EntityToDeleteSQL(t1, out pList, q1);
                    affectedRows += _db.ExecuteNonQueryWithTransaction(sql, pList);
                }
                if (t2 != null && q2 != null)
                {
                    sql = EntityToDeleteSQL(t2, out pList, q2);
                    affectedRows += _db.ExecuteNonQueryWithTransaction(sql, pList);
                }
                if (t3 != null && q3 != null)
                {
                    sql = EntityToDeleteSQL(t3, out pList, q3);
                    affectedRows += _db.ExecuteNonQueryWithTransaction(sql, pList);
                }
                if (t4 != null && q4 != null)
                {
                    sql = EntityToDeleteSQL(t4, out pList, q4);
                    affectedRows += _db.ExecuteNonQueryWithTransaction(sql, pList);
                }
                _db.CommitTransaction();
            }
            catch
            {
                _db.RollbackTransaction();
            }
            return affectedRows > 0;
        }

        public string EntityToDeleteSQL<TEntity>(TEntity t, out IList<DbParameter> pList, IQueryInfo queryInfo)
        {
            pList = new List<DbParameter>();
            StringBuilder sb = new StringBuilder();
            object v = null;
            sb.AppendFormat("DELETE FROM {0} ", queryInfo.TableName);
            if (HasPrimaryKey(t, queryInfo, out v))
            {
                sb.AppendFormat("WHERE {0} = @ID", queryInfo.PrimaryKey);
                pList.Add(new SqlParameter("@ID", v));
            }
            else
            {
                sb.AppendFormat("WHERE ");
                foreach (PropertyInfo info in typeof(TEntity).GetProperties())
                {
                    v = info.GetValue(t, null);
                    if (!SafeTypeCheck(v)) continue;
                    sb.AppendFormat("{0} = @{1},", info.Name, info.Name);
                    pList.Add(new SqlParameter("@" + info.Name, v));
                }
                if (sb[sb.Length - 1] == ',')
                    sb.Length--;//去掉多余的一个逗号
            }


            return sb.ToString();
        }
        /// <summary>
        /// 判断指定的Entity是否有主键信息值
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        private bool HasPrimaryKey<TEntity>(TEntity t, IQueryInfo queryInfo, out object value)
        {
            value = null;
            foreach (PropertyInfo info in typeof(TEntity).GetProperties())
            {
                if (info.Name == queryInfo.PrimaryKey)
                {
                    value = info.GetValue(t, null);
                    return SafeTypeCheck(value);
                }
            }
            return false;
        }
        protected virtual string EntityToUpdateSQL<TEntity>(TEntity t, out IList<DbParameter> pList)
        {
            bool hasPK = false;
            pList = new List<DbParameter>();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE {0} SET ", QueryInfo.TableName);
            foreach (PropertyInfo info in typeof(TEntity).GetProperties())
            {
                object v = info.GetValue(t, null);
                if (!SafeTypeCheck(v)) continue;
                if (info.Name == QueryInfo.PrimaryKey)
                {
                    hasPK = true;
                    pList.Add(new SqlParameter("@ID", v));
                    continue;
                }
                sb.AppendFormat("{0} = @{1},", info.Name, info.Name);
                pList.Add(new SqlParameter("@" + info.Name, v));
            }
            if (sb[sb.Length - 1] == ',')
                sb.Length--;//去掉多余的一个逗号
            if (hasPK)
                sb.AppendFormat(" WHERE {0} = @ID", QueryInfo.PrimaryKey);
            return sb.ToString();
        }

        /// <summary>
        /// 值为null，List，Array时返回False
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool SafeTypeCheck(object v)
        {
            if (v == null) return false;
            if (v is System.Collections.IList) return false;
            if (v is Array) return false;
            return true;
        }
        /// <summary>
        /// 从一个Entity转成SQL字段
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual string EntityToInsertSQL<TEntity>(TEntity t, out IList<DbParameter> pList)
        {
            pList = new List<DbParameter>();
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            //"INSERT INTO (field1,field2) VALUES (@1,@2);
            sbFields.AppendFormat("INSERT INTO {0} (", QueryInfo.TableName);
            sbValues.AppendFormat(" VALUES (");
            foreach (PropertyInfo info in typeof(TEntity).GetProperties())
            {
                if (info.Name == QueryInfo.PrimaryKey) continue;
                object v = info.GetValue(t, null);
                if (!SafeTypeCheck(v)) continue;
                sbFields.AppendFormat("{0},", info.Name);
                sbValues.AppendFormat("@{0},", info.Name);
                pList.Add(new SqlParameter("@" + info.Name, v));
            }
            sbFields.Length--;
            sbValues.Length--;
            sbFields.Append(")");
            sbValues.Append(")");
            sbFields.Append(sbValues);
            return sbFields.ToString();
        }

        protected virtual TEntity DataReaderToEntity<TEntity>(IDataReader dr)
        {
            TEntity local = Activator.CreateInstance<TEntity>();
            foreach (PropertyInfo info in local.GetType().GetProperties())
            {
                try
                {
                    if (dr[info.Name].ToString() != "")
                        info.SetValue(local, dr[info.Name] ?? "", null);
                }
                catch
                {
                }
            }
            return local;
        }

        /// <summary>
        /// 通过传入一个DataReader返回一个T的实例
        /// 调用这个方法的前提需要保存你的实例类和数据库的字段名一一对应
        /// 它是利用反射机制实现的
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        protected virtual T DataReaderToEntity(IDataReader dr)
        {
            return DataReaderToEntity<T>(dr);
        }

        /// <summary>
        /// 通过完整的Sql语句获取List集合
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<T> GetList(string strSql, DbParameter[] parameters)
        {
            return GetList<T>(strSql, parameters);
        }

        private List<TEntity> GetList<TEntity>(string strSql,DbParameter[] parameters)
            where TEntity:BaseEntity,new()
        {
            TEntity item = new TEntity();
            List<TEntity> list = new List<TEntity>();
            IDataReader reader = _db.ExecuteReader(strSql, parameters);
            while (reader.Read())
            {
                item = this.DataReaderToEntity<TEntity>(reader);
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// abstract和interface这2个是架构狮为程序猿挖坑专用名词
        /// 这里挖了一个坑让你们来填，返回我要的表名、字段名、降序排？、返回哪些字段？....
        /// </summary>
        public abstract IQueryInfo QueryInfo { get; }
    }
}
