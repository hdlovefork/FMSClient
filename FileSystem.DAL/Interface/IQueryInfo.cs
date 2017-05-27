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
    /// 该接口告诉BaseService类查询数据库时按哪些要求获取数据
    /// </summary>
    public interface IQueryInfo
    {
        #region 如果要使用子类中的各种方法和属性，就必须重写以下属性
        /// <summary>
        /// 设定默认排序
        /// </summary>
        bool IsDescending { get; }

        /// <summary>
        /// 设定默认主键，为""或null或空白字时不能更新数据
        /// </summary>
        string PrimaryKey { get; }

        /// <summary>
        /// 设定默认查询字段，为""或null或空白字时为*
        /// </summary>
        string SelectedFields { get; }

        /// <summary>
        /// 设置默认排序字段，为""或null或空白字时不排序
        /// </summary>
        string SortField { get; }

        /// <summary>
        /// 设置默认表名，必填
        /// </summary>
        string TableName { get; }

        IList<Relationship> Relationship { get; }
        #endregion
    }
}
