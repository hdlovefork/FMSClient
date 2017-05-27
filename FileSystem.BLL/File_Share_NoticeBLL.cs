using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using FileSystem.Data.SqlServer;

namespace FileSystem.BLL
{
   public class File_Share_NoticeBLL
    {
       public bool Add(File_Share_Notice f) {
           return new File_Share_NoticeService().Add(f);
       }
    }
}
