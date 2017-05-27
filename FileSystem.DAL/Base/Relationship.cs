/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-16 12:40:41 
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
using System.Linq;
using System.Text;

namespace FileSystem.DAL
{
    public class Relationship
    {
        private Relationship() { }
        /// <summary>
        /// 对指定表名进行关联删除
        /// </summary>
        /// <param name="tableName">要删除关联表名称</param>
        public Relationship(string tableName)
        {
            TableName = tableName;
        }
        /// <summary>
        /// 关系表的名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 关联表中外键的字段名
        /// </summary>
        public string FieldName { get; set; }
    }
}
