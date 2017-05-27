﻿/**************************************************************** 
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

namespace FileSystem.Entity
{
    /// <summary>
    /// 实体类User。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User:SimpleUser
    {
		/// <summary>
		/// 
		/// </summary>
		public int UserID { get; set; }		
		/// <summary>
		/// 
		/// </summary>
		public bool? UserSex { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UserAddress { get; set; }

		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? UserCreateTime { get; set; }
        /// <summary>
        /// 账号是否启用
        /// </summary>
        public bool UserEnable { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string UserMobile { get; set; }
        public override string ToString()
        {
            return UserName ;
        }
    }
}