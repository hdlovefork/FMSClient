using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Model
{
   public class File_User_Notice:BaseEntity
    {
       DateTime _createTime;

       public File_User_Notice()
       {
           _createTime = DateTime.Now;
       }
       public int FromUserID { get; set; }
       public int ToUserID { get; set; }
       public int FileID { get; set; }
       public DateTime CreateTime { get { return _createTime; } set { _createTime = value; } }
       public bool IsRead { get; set; }
       public int NoticeID { get; set; }
    }
}
