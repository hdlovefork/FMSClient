using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Data.SqlServer;
using FileSystem.Model;

namespace FileSystem.BLL
{
   public class RoleBLL
    {
       public List<ACL_Role> GetAll() {
           return new RoleService().GetAll();
       }
    }
}
