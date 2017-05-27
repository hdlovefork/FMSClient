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
using FileSystem.Model;

namespace FileSystem.Data.SqlServer
{
    /// <summary>
    /// 用户类，代码编写模板，每位开发者都需要按照此模式进行代码编写，框架才可以识别。
    /// </summary>
    public class UserService : BaseService<User>
    {
        /// <summary>
        /// 每个派生类必做
        /// </summary>
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("User"); }
        }
        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        public List<User> AllUserMsg()
        {
            List<User> users = base.Find();
            return users;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user) {
            string sql = string.Format("insert into FS_User(UserAddress,UserTel)values('{0}','{1}')", user.UserAddress, user.UserRealName);
            int i = db.ExecuteNonQuery(sql,null);
            return i;
        }

        public int UpdateUser(User user) {
            bool result = base.Update(user);
            return result ? 1 : 0;
        }
    }
}
