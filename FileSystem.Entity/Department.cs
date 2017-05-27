/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-10 12:59:51 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 数据库实体类
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;

namespace FileSystem.Entity
{
    /// <summary>
    /// 实体类Department。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Department:BaseEntity
    {
        List<Position> _pos = new List<Position>();

        public Department()
        {
            _pos = new List<Position>();
        }
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName { get; set; }

        public override string ToString()
        {
            return DepartmentName;
        }

       public List<Position> Positions
        {
            get { return _pos; }
            set { _pos = value; }
        }
    }
}