/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 0:37:15 
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DAL
{
    /// <summary>
    /// 所有访问数据库操作的接口都继承我吧
    /// 这个接口主要用于对BaseLogic类的T作类型限制
    /// 我们经常把一些东西都继承自一个基类是个好的习惯，哪怕这个基类里面是空的
    /// </summary>
    public interface IService
    {
        
    }
}
