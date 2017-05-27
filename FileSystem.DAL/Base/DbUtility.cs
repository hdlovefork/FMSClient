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
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace FileSystem.DAL
{
    public class DbUtility
    {
        public string ConnectionString { get; set; }
        private DbProviderFactory _providerFactory;
        private DbTransaction _transactionObj = null;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>  
        /// <param name="providerType">数据库类型枚举，参见<paramref name="providerType"/></param>  
        public DbUtility(string connectionString, DbProviderType providerType)
        {
            ConnectionString = connectionString;
            _providerFactory = ProviderFactory.GetDbProviderFactory(providerType);
            if (_providerFactory == null)
            {
                throw new ArgumentException("Can't load DbProviderFactory for given value of providerType");
            }
        }

        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <returns></returns>    
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }

        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <returns></returns>    
        public int ExecuteNonQuery(string sql, DbParameter[] parameters)
        {
            if (parameters == null) return 0;
            List<DbParameter> list = new List<DbParameter>();
            foreach (var p in parameters)
            {
                list.Add(p);
            }
            return ExecuteNonQuery(sql, list, CommandType.Text);
        }

        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                command.Connection.Close();
                return affectedRows;
            }
        }

        public int ExecuteNonQueryWithTransaction(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            if (_transactionObj == null) throw new Exception("你应该先调用BeginTransaction()方法开启事务");
            using (DbCommand cmd=CreateDbCommandWithTransaction(sql,parameters, commandType))
            {
                cmd.Transaction = _transactionObj;
                return cmd.ExecuteNonQuery();
            }
        }
        #region 连接操作
        private void OpenConn(DbConnection conn)
        {
            if (conn == null) conn = _providerFactory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        private void CloseConn(DbConnection conn)
        {
            if (conn == null) return;
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Dispose();
            conn = null;
        }
        #endregion

        #region 事务操作
        public void BeginTransaction()
        {
            if (_transactionObj == null)
            {
                DbConnection conn = _providerFactory.CreateConnection();
                OpenConn(conn);
                _transactionObj = conn.BeginTransaction();
            }
        }

        public void RollbackTransaction()
        {
            if (_transactionObj == null) return;
            _transactionObj.Rollback();
            ReleaseTransaction();

        }
        public void CommitTransaction()
        {
            if (_transactionObj == null) return;
            _transactionObj.Commit();
            ReleaseTransaction();
        }

        private void ReleaseTransaction()
        {
            if (_transactionObj == null) return;
            DbConnection conn = _transactionObj.Connection;
            _transactionObj = null;
            CloseConn(conn);
        }
        #endregion

        /// <summary>     
        /// 执行一个查询语句，返回一个关联的DataReader实例     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>   
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters)
        {
            return ExecuteReader(sql, parameters, CommandType.Text);
        }

        public int ExecuteNonQueryWithTransaction(string sql, IList<DbParameter> pList)
        {
           return ExecuteNonQueryWithTransaction(sql, pList, CommandType.Text);
        }

        /// <summary>     
        /// 执行一个查询语句，返回一个关联的DataReader实例     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>   
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbCommand command = CreateDbCommand(sql, parameters, commandType);
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>  
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }

        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                using (DbDataAdapter adapter = _providerFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }

        /// <summary>     
        /// 执行一个查询语句，返回查询结果的第一行第一列     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>     
        /// <returns></returns>     
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }

        /// <summary>     
        /// 执行一个查询语句，返回查询结果的第一行第一列     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>     
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>     
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                object result = command.ExecuteScalar();
                command.Connection.Close();
                return result;
            }
        }

        public DbParameter CreateDbParameter(string name, object value)
        {
            return CreateDbParameter(name, ParameterDirection.Input, value);
        }

        public DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            DbParameter parameter = _providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        /// <summary>  
        /// 创建一个DbCommand对象  
        /// </summary>  
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        private DbCommand CreateDbCommand(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbConnection connection = _providerFactory.CreateConnection();
            DbCommand command = _providerFactory.CreateCommand();
            connection.ConnectionString = ConnectionString;
            command.CommandTimeout = 0;
            command.CommandText = sql;
            command.CommandType = commandType;
            command.Connection = connection;
            if (!(parameters == null || parameters.Count == 0))
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 基于事务的连接对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        private DbCommand CreateDbCommandWithTransaction(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbCommand command = _providerFactory.CreateCommand();           
            command.CommandText = sql;
            command.CommandTimeout = 0;
            command.CommandType = commandType;
            command.Connection = _transactionObj.Connection;
            if (!(parameters == null || parameters.Count == 0))
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
    }
}
