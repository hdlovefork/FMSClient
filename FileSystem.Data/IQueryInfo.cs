/**************************************************************** 
 * 作    者：顾挺
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
    public interface IQueryInfo
    {
        #region 如果要使用子类中的各种方法和属性，就必须重写以下属性
        /// <summary>
        /// 设定默认排序
        /// </summary>
        bool IsDescending { get; }

        /// <summary>
        /// 设定默认主键
        /// </summary>
        string PrimaryKey { get; }

        /// <summary>
        /// 设定默认查询字段
        /// </summary>
         string SelectedFields { get; }

        /// <summary>
        /// 设置默认排序字段
        /// </summary>
        string SortField { get; }

        /// <summary>
        /// 设置默认表名
        /// </summary>
        string TableName { get; }
        #endregion
    }
}
