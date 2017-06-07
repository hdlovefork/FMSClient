using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using FileSystem.Data.SqlServer;

namespace FileSystem.BLL
{
   public class FileDepartmentBLL
    {
        public bool AddFilDepartment(File_Department acl)
        {
            return new FileDepartmentService().InsertFileDepartment(acl);
        }

        public bool UpdateFileDepartment(File_Department acl)
        {
            return new FileDepartmentService().UpdateFileDepartment(acl);
        }

        public bool DeleteFileDepartment(File_Department acl)
        {
            return new FileDepartmentService().DeleteFileDepartment(acl);
        }
    }
}
