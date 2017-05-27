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

namespace FileSystem.DAL
{
    /// <summary>
    /// 我为你们简单的实现了IQueryInfo这个坑，但我还不知道表名，等你告诉我呢！
    /// 所以你new我的时候你必须调用一个带表名的有参构造函数
    /// 因为无参构造函数被我private了，哈哈^_^
    /// </summary>
    public class BaseQueryInfo : IQueryInfo
    {
        //查询语句中带[]的表名
        private string _sTableName;
        //默认主键为：表名+ID
        private string _sPrimaryKey;
        //默认查询所有字段：*
        private string _sSelectedFields;
        //默认按主键排序
        private string _sSortField;
        //默认升序ASC
        private bool _bIsDescending = false;
        //保存真实的表名
        private string _sRealTableName;

        private IList<Relationship> _relationship;

        /// <summary>
        /// 这是一个无参构造方法，我不让你使用，气死你！
        /// 因为我必须让你告诉我表名，否则我的大坑爸爸(BaseService)不能正常工作
        /// </summary>
        private BaseQueryInfo()
        {
            _relationship = new List<Relationship>();
        }

        /// <summary>
        /// 你要在哪张表中做查询操作
        /// </summary>
        /// <param name="tableName"></param>
        public BaseQueryInfo(string tableName, Relationship[] relationship) : this()
        {
            _sRealTableName = tableName;
            _sTableName = string.Format("[{0}]", tableName);
            if (relationship == null) return;
            foreach (var r in relationship)
            {
                Relationship.Add(r);
            }
        }

        /// <summary>
        /// 你要在哪张表查询数据以及这张表的主键
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKey"></param>
        public BaseQueryInfo(string tableName, string primaryKey, Relationship[] relationship)
            : this(tableName, relationship)
        {
            _sPrimaryKey = primaryKey;
        }

        public BaseQueryInfo(string tableName, string primaryKey, string sortField, Relationship[] relationship)
                : this(tableName, primaryKey, relationship)
        {
            _sSortField = sortField;
        }

        /// <summary>
        /// 你要在哪张表查询数据以及这张表的主键、降序吗？、查哪些字段？、排序字段是什么呢？
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKey"></param>
        /// <param name="isDescending"></param>
        /// <param name="selectedFields"></param>
        /// <param name="sortField"></param>
        public BaseQueryInfo(string tableName, string primaryKey, bool isDescending, string selectedFields, string sortField, Relationship[] relationship)
             : this(tableName, primaryKey,relationship)
        {
            _bIsDescending = isDescending;
            _sSelectedFields = selectedFields;
            _sSortField = sortField;
        }

        public bool IsDescending
        {
            get { return _bIsDescending; }
        }

        public string PrimaryKey
        {
            get { return string.IsNullOrEmpty(_sPrimaryKey) ? _sRealTableName + "ID" : _sPrimaryKey; }
        }

        public string SelectedFields
        {
            get
            {
                return string.IsNullOrEmpty(_sSelectedFields) ? "*" : _sSelectedFields;
            }
        }

        public string SortField
        {
            get { return string.Empty; }
        }

        public string TableName
        {
            get { return _sTableName; }
        }

        public IList<Relationship> Relationship { 
            get{ 
                return _relationship;
            }
        }
    }
}
