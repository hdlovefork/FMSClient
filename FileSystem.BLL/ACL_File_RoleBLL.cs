using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Data.SqlServer;


namespace FileSystem.BLL
{
   public class ACL_File_RoleBLL
    {
       public bool Add(int FileId, int RoleId) {
           return new ACLFileRoleService().Add(FileId,RoleId);
       }
    }
}
