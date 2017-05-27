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
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FileSystem.Data.SqlServer;
using FileSystem.Model;
using FileSystem.Data;

namespace FileSystem.BLL
{
    public class UserBLL
    {
        public List<User> GetAllUser() {
            return new UserService().AllUserMsg();
        }

        public List<User> GetOne(int id){
            return new UserService().FindById(id);
        }

        public List<User> CheckLogin(string userName, string userPwd)
        { 
            string condition = string.Format(@"1>0 
                                 and UserName='{0}'
                                 and UserPassword='{1}'",userName,userPwd);
            List<User> users =  new UserService().Find(condition);
            return users;
        }

        public int AddUser(User user){
            return new UserService().AddUser(user);
        }

        public int UpdateUser(User user) {
            return new UserService().UpdateUser(user);
        }
    }
}
