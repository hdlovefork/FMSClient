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
        public bool Add(File_User_Notice f)
        {
            return new File_Share_NoticeService().Add(f);
        }

        public bool UpdateNotice(int noticeID)
        {
            return new File_Share_NoticeService().UpdateNotice(noticeID);
        }

        public File_User_Notice GetNotice(int uid)
        {
            return new File_Share_NoticeService().SelectNotice(uid);
        }

        public bool DeleteNotice(int noticeID)
        {
            return new File_Share_NoticeService().DeleteNotice(noticeID);
        }

        public bool DeleteNotice(File_User_Notice notice)
        {
            return new File_Share_NoticeService().DeleteNotice(notice.FromUserID, notice.ToUserID, notice.FileID);
        }
    }
}
