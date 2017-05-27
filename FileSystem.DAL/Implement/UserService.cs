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
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FileSystem.Entity;
using System.Data.SqlClient;

namespace FileSystem.DAL
{
    /// <summary>
    /// 用户管理实现类，实现对用户增删改查及后台权限修改
    /// 所有和数据层打交道的类都继承自BaseService，因为它帮我们实现了很多复杂的功能
    /// 我们只要调用它里面的一些方法就行，甚至不需要写SQL语句，建议同学们看看BaseService
    /// 里面是怎么实现的
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        /// <summary>
        /// 这是BaseService为我们留的一个坑，需要我们来填坑（返回一个实现IQueryInfo的接口）
        /// 但挖坑者为我们准备了一些石子(BaseQueryInfo)我们只要
        /// 稍微动下铲子就行了——new BaseQueryInfo("表名")
        ///  LAMBDA（拉姆达表达式）写法更简便哦下面一行搞掂：
        ///  public override IQueryInfo QueryInfo => new BaseQueryInfo("User");
        /// </summary>
        public override IQueryInfo QueryInfo
        {
            //告诉BaseService我要搜索User表
            get
            {
                return new BaseQueryInfo("User",
                                          new Relationship[] {
                                                new Relationship("ACL_File_User"),
                                                new Relationship("ACL_User_Role"),
                                                new Relationship("User_Department_Position"),
                                                new Relationship("Comment"),
                                            }
                                          );

            }
        }

        public bool DeleteUser(int userID)
        {
            return DeleteByKey(userID.ToString ());
        }

        public List<Department> GetDepartmentByUID(int uid)
        {
            throw new NotImplementedException();
        }

        public IList<Role> GetRolesByID(int userID)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userName, string pwd)
        {
            return FindSingle("UserName=@UserName AND UserPassword=@UserPassword",
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@UserPassword", pwd)
                );
        }

        public List<User> GetUsersByRID(int rid)
        {
            return Find(new BaseQueryInfo("View_User_Role",null), "RoleID=@RoleID",
                  new SqlParameter("@RoleID", rid)
                );
        }

        public List<User> GetUsers()
        {
            return Find(string.Empty);
        }

        public bool InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            return Update(user);
        }
    }
}
