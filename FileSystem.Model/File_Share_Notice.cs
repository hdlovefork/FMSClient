using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Model
{
   public class File_Share_Notice:BaseEntity
    {
       DateTime _createTime;

       public File_Share_Notice()
       {
           _createTime = DateTime.Now;
       }
       public int FromUserID { get; set; }
       public int ToUserID { get; set; }
       public int FileID { get; set; }
       public DateTime CreatTime { get { return _createTime; } set { _createTime = value; } }
       public bool IsRead { get; set; }
       public int File_Share_Notice_ID { get; set; }
    }
}
