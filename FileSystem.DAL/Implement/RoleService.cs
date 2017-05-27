/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 16:08:21 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using FileSystem.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DAL
{
    public class RoleService : BaseService<Role>,IRoleService
    {
        public override IQueryInfo QueryInfo {
            get
            {
                return new BaseQueryInfo("ACL_Role",
                new Relationship[] { new Relationship("ACL_Role_Function"),
                                 new Relationship("ACL_File_Role"),
                                 new Relationship("ACL_User_Role"),
                                });
            }
        }

        public List<Role> GetRoles()
        {
            return Find();
        }

        public List<Role> GetRolesByUID(int uid)
        {
            throw new NotImplementedException();
        }

        //public int HqyhID(int rid)
        //{
        //    return Find(new BaseQueryInfo("View_User_Role"), "RoleID=@RoleID",
        //          new SqlParameter("@RoleID", rid)
        //        );
        //}
    }
}
