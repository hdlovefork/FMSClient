/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-16 20:35:17 
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

namespace FileSystem.Service
{
    public class AuthPermission
    {
        /// <summary>
        /// 判断用户是否具有指定权限操作
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="fileID">文件ID</param>
        /// <param name="access">访问动作</param>
        /// <returns></returns>
        public static bool Auth(int uid, int fileID, FilePermission access)
        {
            FileAccessService fileService = new FileAccessService();
            File file = fileService.GetFileByFID(fileID);
            if (file == null) return false;
            //1.判断文件是否属于自己
            if (file.UserID == uid)
            {
                //if (CheckFilePermission(file.FileOwner, access))
                    return true;
            }
            //2.判断自己的部门是否和文件所在同一个部门
            IList<Department> fileDepartment = fileService.GetDepartmentByFID(fileID);
            IList<Department> userDepartment = fileService.GetDepartmentByUID(uid);
            if (CheckFileDepartment(fileDepartment, userDepartment))
            {
                //用戶处于文件所属组中
                //判断用户是否可以执行指定操作
                //if (CheckFilePermission(file.FileRole, access))
                    return true;
            }
            //3.判断其它组是否能执行指定的操作
            //if (CheckFilePermission(file.FileOther, access))
                return true;
            //4.判断文件是否借阅给当前用户ID
            if (access == FilePermission.Read && fileService.IsShareFile(uid, fileID))
                return true;
            //5.判断用户是否属于文件所属部门
            if (access == FilePermission.Read)
            {
                //List<Department> fileDepartment = fileService.GetDepartmentByFID(fileID);
                //List<Department> userDepartment = fileService.GetDepartmentByUID(uid);
                //if (CheckFileDepartment(userDepartment, fileDepartment))
                //{
                //    return true;
                //}
            }
            return false;
        }

        private static bool CheckFileDepartment(List<Department> userDepartment, List<Department> fileDepartment)
        {
            foreach (var d1 in userDepartment)
            {
                foreach (var d2 in fileDepartment)
                {
                    if (d1.DepartmentID == d2.DepartmentID)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证当前用户所处角色组是否属于文件的角色组
        /// </summary>
        /// <param name="userRoles">用户所处角色组</param>
        /// <param name="fileRoles">文件所属角色组</param>
        /// <returns></returns>
        private static bool CheckFileDepartment(IList<Department> fileDepartment, IList<Department> userDepartment)
        {
            foreach (var fr in fileDepartment)
            {
                foreach (var ur in userDepartment)
                {
                    if (fr.DepartmentID == ur.DepartmentID) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证当前持有的权限是否可以做指定的操作
        /// </summary>
        /// <param name="holdPermission">当前持有权限</param>
        /// <param name="access">目标操作</param>
        /// <returns></returns>
        private static bool CheckFilePermission(int holdPermission, FilePermission access)
        {
            return ((int)access & holdPermission) == (int)access;
        }
    }
}
