/**************************************************************** 
 * 作    者：费彬彬
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
using FileSystem.Model;
using FileSystem.Data.SqlServer;

namespace FileSystem.BLL
{
   public class DepBLL
    {
       public List<Department> GetDepTree() {
           return new DepartmentService().GetDepTree();
       
       }

       public List<Department> GetAll() {
           return new DepartmentService().Find();
       }
       public IList<Department> GetDepComBox()
       {
           return new DepartmentService().GetDepComBox();
       
       }
    }
}
