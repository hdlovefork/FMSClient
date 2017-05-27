using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;

namespace FileSystem.Data.SqlServer
{
   public class RoleService:BaseService<ACL_Role>
    {
       public override IQueryInfo QueryInfo
       {
           get { return new BaseQueryInfo("ACL_Role","RoleID"); }
       }
       public List<ACL_Role> GetAll() {
           return base.Find();
       }
    }
}
