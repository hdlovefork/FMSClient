/**************************************************************** 
 * 作    者：陶湘程
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
using FileSystem.Model;

namespace FileSystem.Data.SqlServer
{
    public class ACLFileUserService:BaseService<ACL_File_User>
    {
        /// <summary>
        /// 每个派生类必做
        /// </summary>
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("ACL_File_User"); }
        }

        public bool Add(ACL_File_User user) {
            return base.Insert(user);
        }

        public int MaxId()
        {
            string sql = string.Format(@" select FileID,UserID from ACL_File_User where FileID = (select max(FileID) from ACL_File_User)");
            List<ACL_File_User> acL = base.Find(sql);
            ACL_File_User acL1 = acL[0] as ACL_File_User;
            return Convert.ToInt32(acL1.FileID);
        }
        public bool AddFilUser(ACL_File_User acl)
        {
            return base.Insert(acl);
        }
    }
}
