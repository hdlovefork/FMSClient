using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Data.SqlServer;
using System.Data;

namespace FileSystem.BLL
{
   public class File_ShareBLL
    {
       public bool AddFile_Share(int FileId, int UserId) {
           return new File_ShareService().AddFile_Share(FileId,UserId);
       }
       public DataTable GetFile_Share(int UserId) {
           return new File_ShareService().GetFile_Share(UserId);
       
       }

       public bool AddFile_Dep(int FileId, int DepID)
       {
           return new File_ShareService().AddFile_Dep(FileId, DepID);

       }
    }
}
