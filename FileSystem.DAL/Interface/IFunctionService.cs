/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 14:03:31 
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
    public interface IFunctionService:IService
    {
        /// <summary>
        /// 根据PID获取它的子级Function
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<Function> GetFunctions(int pid);

        /// <summary>
        /// 获取所有Function
        /// </summary>
        /// <returns></returns>
        List<Function> GetFunctions();

        Function GetParentFunctionByPID(int pid);

        bool DeleteFunctionByID(int id);

        bool InsertFunction(Function f);

        bool UpdateFunction(Function f);
        Function GetFunctionRole(string  func);
    }
}
