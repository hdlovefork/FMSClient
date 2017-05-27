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
       public bool Add(File_Department ACL) {
           return new FileDepartmentService().Add(ACL);
       
       }
    }
}
