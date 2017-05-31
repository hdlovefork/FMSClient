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

namespace FileSystem.Data
{
    /// <summary>
    /// 高大尚的底层查询服务类，里面有很多神奇的方法，让你抵不住我的诱惑
    /// 如果想使用我，请叫我“爸爸”（继承我），我将帮助你拿到数据库的数据
    /// </summary>
    /// <typeparam name="T">你要返回的Entity类型（实体类）</typeparam>
    public abstract class BaseService<T> where T : new()
    {
        /// <summary>
        /// 数据库连接字符串，通过app.config文件修改成你的，这样写的好处在于可以在不修改程序代码的前提下换数据库
        /// 因为是在外部操作
        /// </summary>
        private static string _conn = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        /// <summary>
        /// 数据库操作帮助类的实例对象
        /// </summary>
        public static DbUtility db = new DbUtility(_conn, DbProviderType.SqlServer);

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

        /// <summary>
        /// 根据条件查询多条数据-单表,如果查询所有记录condition请设为string.Empty
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public List<T> Find(string condition, params DbParameter[] paramList)
        {
            string str = string.Format("SELECT {0} FROM {1}{2} ORDER BY {3} {4}", QueryInfo.SelectedFields, QueryInfo.TableName, string.IsNullOrEmpty(condition) ? string.Empty : " WHERE " + condition, QueryInfo.PrimaryKey, QueryInfo.IsDescending ? "DESC" : "ASC");
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
            T local = default(T);
            List<T> list = this.Find(condition, paramList);
            if (list.Count > 0)
            {
                local = list[0];
            }
            return local;
        }

        public TEntity FindSingle<TEntity>(IQueryInfo q,string condition, params DbParameter[] paramList)
            where TEntity:new()
        {
            TEntity local = default(TEntity);
            List<TEntity> list = this.Find<TEntity>(q,condition, paramList);
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

        /// <summary>
        /// 根据主键删除数据-单表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByKey(string id)
        {
            //"UserID=@ID"
            string condition = string.Format("DELETE FROM {0} WHERE {1} = @ID", QueryInfo.TableName, QueryInfo.PrimaryKey);
            SqlParameter parameter = new SqlParameter("@ID", id);
            return db.ExecuteNonQuery(condition, new SqlParameter[] { parameter }) > 0;
        }

        public bool Insert(T t)
        {
            IList<DbParameter> pList;
            string sql = EntityToSqlField(t, out pList);
            if (pList.Count == 0) return false;
            return db.ExecuteNonQuery(sql, pList) > 0;
        }

        public bool Update(T t)
        {
            IList<DbParameter> pList;
            string sql = EntityToUpdateSQL(t, out pList);
            if (pList.Count == 0) return false;
            return db.ExecuteNonQuery(sql, pList) > 0;
        }

        protected virtual string EntityToUpdateSQL(T t, out IList<DbParameter> pList)
        {
            pList = new List<DbParameter>();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE {0} SET ", QueryInfo.TableName);
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                object v = info.GetValue(t, null);
                if (info.Name == QueryInfo.PrimaryKey)
                {
                    if (v == null) throw new Exception(QueryInfo.PrimaryKey + "的值不能为null");
                    pList.Add(new SqlParameter("@ID", info.GetValue(t, null)));
                    continue;
                }
                if (v == null) continue;
                sb.AppendFormat("{0} = @{1},", info.Name, info.Name);
                pList.Add(new SqlParameter("@" + info.Name, v));
            }
            sb.Length--;
            sb.AppendFormat(" WHERE {0} = @ID", QueryInfo.PrimaryKey);
            return sb.ToString();
        }

        /// <summary>
        /// 从一个Entity转成SQL字段
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual string EntityToSqlField(T t, out IList<DbParameter> pList)
        {
            pList = new List<DbParameter>();
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            //"INSERT INTO (field1,field2) VALUES (@1,@2);
            sbFields.AppendFormat("INSERT INTO {0} (", QueryInfo.TableName);
            sbValues.AppendFormat(" VALUES (");
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if (info.Name == QueryInfo.PrimaryKey) continue;
                sbFields.AppendFormat("{0},", info.Name);
                sbValues.AppendFormat("@{0},", info.Name);
                pList.Add(new SqlParameter("@" + info.Name, info.GetValue(t,null)));
            }
            sbFields.Length--;
            sbValues.Length--;
            sbFields.Append(")");
            sbValues.Append(")");
            sbFields.Append(sbValues);
            return sbFields.ToString();
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
            T local = Activator.CreateInstance<T>();
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
        /// 通过完整的Sql语句获取List集合
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<T> GetList(string strSql, DbParameter[] parameters)
        {
            T item = default(T);
            List<T> list = new List<T>();
            IDataReader reader = db.ExecuteReader(strSql, parameters);
            while (reader.Read())
            {
                item = this.DataReaderToEntity(reader);
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

        public List<TEntity> Find<TEntity>(IQueryInfo q, string condition, params DbParameter[] paramList)
           where TEntity :  new()
        {
            string str = string.Format("SELECT {0} FROM {1}{2}", q.SelectedFields, q.TableName, string.IsNullOrWhiteSpace(condition) ? string.Empty : " WHERE " + condition);
            if (!string.IsNullOrWhiteSpace(q.SortField))//排序字段不为空时才排序
                str += string.Format(" ORDER BY {0} {1}", q.SortField, q.IsDescending ? "DESC" : "ASC");
            return this.GetList<TEntity>(str, paramList);
        }

        private List<TEntity> GetList<TEntity>(string strSql, DbParameter[] parameters)
            where TEntity :  new()
        {
            TEntity item = default(TEntity);
            List<TEntity> list = new List<TEntity>();
            IDataReader reader = db.ExecuteReader(strSql, parameters);
            while (reader.Read())
            {
                item = this.DataReaderToEntity<TEntity>(reader);
                list.Add(item);
            }
            reader.Close();
            return list;
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

    }
}
