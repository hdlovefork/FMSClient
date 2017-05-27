using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;

namespace FileSystem.Data.SqlServer
{
   public class File_Share_NoticeService:BaseService<File_Share_Notice>
    {
       public override IQueryInfo QueryInfo
       {
           get { return new BaseQueryInfo("File_Share_Notice","File_Share_Notice_ID"); }
       }
       public bool Add(File_Share_Notice f) {
           return base.Insert(f);
       }
    }
}
