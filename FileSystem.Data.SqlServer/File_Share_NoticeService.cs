using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;

namespace FileSystem.Data.SqlServer
{
   public class File_Share_NoticeService:BaseService<File_User_Notice>
    {
       public override IQueryInfo QueryInfo
       {
           get { return new BaseQueryInfo("File_User_Notice","NoticeID"); }
       }
       public bool Add(File_User_Notice f) {
           return base.Insert(f);
       }
    }
}
