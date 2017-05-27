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
 * Copyright @ guting 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Data
{
     public class BaseQueryInfo:IQueryInfo
    {
         private string _sTableName;
         private string _sPrimaryKey;
         private string _sSelectedFields;
         private string _sSortField;
         private bool _bIsDescending = false;
         private string _sTempTableName;
         private BaseQueryInfo() { }

         public BaseQueryInfo(string tableName)
         {
             _sTempTableName = tableName;
             _sTableName = string.Format("[{0}]",tableName);
         }

         public BaseQueryInfo(string tableName, string primaryKey)
             :this(tableName) {
             _sPrimaryKey = primaryKey;
         }

         public BaseQueryInfo(string tableName, string primaryKey, bool isDescending, string selectedFields, string sortField)
             :this(tableName,primaryKey)
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
            get { return string.IsNullOrEmpty(_sPrimaryKey) ? _sTempTableName + "ID" : _sPrimaryKey; }
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
            get { return string.IsNullOrEmpty(_sSortField) ? _sTempTableName + "ID" : _sSortField; }
        }

        public string TableName
        {
            get { return _sTableName; }
        }
    }
}
