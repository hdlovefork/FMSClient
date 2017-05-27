/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 14:05:19 
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
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DAL
{
    public class FunctionService : BaseService<Function>, IFunctionService
    {
        public override IQueryInfo QueryInfo{
            get
            {
                return new BaseQueryInfo("ACL_Function", "FunctionID",
                    new Relationship[] { new Relationship("ACL_Role_Function") }
                );
            }
        }

        public bool DeleteFunctionByID(int id)
        {
            return DeleteByKey(id.ToString());
        }

        public Function GetFunctionRole(string  func)
        {


            //未实现↓


            return FindSingle ("FunctionControl = @Control", new SqlParameter("@Control", func));
        }

        public List<Function> GetFunctions(int pid)
        {
            return Find("FunctionPID = @PID", new SqlParameter("@PID", pid));
        }

        public List<Function> GetFunctions()
        {
            return Find();
        }

        public Function GetParentFunctionByPID(int pid)
        {
            return FindSingle("FunctionID=@PID", new SqlParameter("@PID", pid));
        }

        public bool InsertFunction(Function f)
        {
            int i = Insert(f);
            return i > 0;
        }

        public bool UpdateFunction(Function f)
        {
            return Update(f);
        }
    }
}
