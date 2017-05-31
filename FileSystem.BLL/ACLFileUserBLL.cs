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
using FileSystem.Data.SqlServer;

namespace FileSystem.BLL
{
    public class ACLFileUserBLL
    {
        public bool Add(ACL_File_User user)
        {
            return new ACLFileUserService().Add(user);
        }

        public int MaxId()
        {
            return new ACLFileUserService().MaxId();
        }

        public bool AddFileUser(ACL_File_User acl)
        {
            return new ACLFileUserService().InsertFileUser(acl);

        }

        public bool UpdateFileUser(ACL_File_User acl)
        {
            return new ACLFileUserService().UpdateFileUser(acl);
        }

        public bool DeleteFileUser(ACL_File_User acl)
        {
            return new ACLFileUserService().DeleteFileUser(acl);
        }
    }
}
