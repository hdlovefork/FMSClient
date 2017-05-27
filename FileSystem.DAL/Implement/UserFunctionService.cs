/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-14 12:39:41 
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

namespace FileSystem.DAL
{
    public class UserFunctionService : BaseService<Function>, IUserFunctionService
    {
        public override IQueryInfo QueryInfo {
            get
            {
                return  new BaseQueryInfo("View_User_Role_Function",
                    null
                );
            }
        }

        public Function GetFuncitonByUID(int uid, string functionControl)
        {
           return FindSingle("UserID=@UserID AND FunctionControl=@FunctionControl",
                new SqlParameter("@UserID", uid),
                new SqlParameter("@FunctionControl",functionControl)
                );
        }
    }
}
