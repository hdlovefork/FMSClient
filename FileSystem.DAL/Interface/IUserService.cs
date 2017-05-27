/**************************************************************** 
 * 作    者：黄鼎 
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
using FileSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DAL
{
    /// <summary>
    /// 用户数据访问接口
    /// 考虑到用户登录、用户管理界面的业务，以下详细说明：
    /// 1.用户登录：需要从界面拿到用户名、密码然后去数据库查询是不是有这条记录，有记录则返回这个用户的其它详细信息显示在底部的状态栏
    /// 2.所有用户展示出来：那么肯定需要无条件查询返回所有用户集合吧！List<User>
    /// 3.显示用户所处的部门：点击左边的用户，通过他的UserID查到他属于哪些部门，注意是哪些，因为有可能你在多个部门哦！所以需要返回List<Department>，而且要在中间表User_Department中查询
    /// 4.添加用户：公司招新人了，我们要为他们添加账号让新人可以使用前台进行文件管理，需要构造一个User再插入数据库
    /// 5.删除用户：老用户被挖墙脚了，哎~删除他吧，恐怕不会回来了，根据他的UserID删除就行了，因为它已经显示在左边的TreeView里面了，UserID你肯定之前就已经拿到了
    /// 6.更新用户：有员工电话改了，地址可能也改了，没办法new User出来将所有信息构造好提交到数据库吧！
    /// 7.用户权限：有员工在公司做了很多年了，领导说可以为他提权，行！先查Function表列出所有权限吧，然后通过UserID在查出他当前有哪些权限，让他也当当管理员~
    /// </summary>
    public interface IUserService:IService
    {
        /// <summary>
        /// 查询某个用户所在的角色组
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>返回用户所在角色组集合</returns>
        IList<Role> GetRolesByID(int userID);

        List<Department> GetDepartmentByUID(int uid);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();
        /// <summary>
        /// 向数据库插入一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool InsertUser(User user);

        /// <summary>
        /// 更新数据库对应用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool UpdateUser(User user);

        /// <summary>
        /// 删除指定ID的用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool DeleteUser(int userID);

        /// <summary>
        /// 通过用户名和密码获取用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        User GetUser(string user, string pwd);

        List<User> GetUsersByRID(int rid);
    }
}
