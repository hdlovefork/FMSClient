/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 11:41:17 
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
    public interface IDeapartService:IService
    {
        /// <summary>
        /// 获得所有部门
        /// </summary>
        /// <returns></returns>
        List<Department> GetDepartments();

        /// <summary>
        /// 根据用户ID获取他所属的全部部门
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<Department> GetDepartmentsByUID(int uid);


    }
}
