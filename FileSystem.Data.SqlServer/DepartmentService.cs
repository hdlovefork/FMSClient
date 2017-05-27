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
using System.Data;

namespace FileSystem.Data.SqlServer
{
   public class DepartmentService:BaseService<Department>
    {
       public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("Department"); }
        }


       public List<Department> GetDepTree(){
           List<Department> lst = base.Find();
           return lst;
       
       }
       public IList<Department> GetDepComBox()
       {
           string condition = string.Format("select * from [Department]");
           DataTable dt = db.ExecuteDataTable(condition, null);
           return ModelConvertHelper<Department>.ConvertToModel(dt);
       }
    }
}
