using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using System.Data.SqlClient;

namespace FileSystem.Data.SqlServer
{
    public class File_Share_NoticeService : BaseService<File_User_Notice>
    {
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("File_User_Notice", "NoticeID"); }
        }
        public bool Add(File_User_Notice f)
        {
            string sql = "INSERT INTO [File_User_Notice] (FromUserID,ToUserID,FileID) VALUES (@FromUserID,@ToUserID,@FileID)";
            return db.ExecuteNonQuery(sql,
                new SqlParameter("@FromUserID",f.FromUserID),
                new SqlParameter("@ToUserID", f.ToUserID),
                new SqlParameter("@FileID", f.FileID)
                ) > 0;
        }

        public bool UpdateNotice(int noticeID)
        {
            string sql = "UPDATE [File_User_Notice] SET IsRead=1 WHERE NoticeID=@NoticeID";
            return db.ExecuteNonQuery(sql,
                new SqlParameter("@NoticeID", noticeID)
                ) > 0;
        }

        public File_User_Notice SelectNotice(int uid)
        {
            return FindSingle<File_User_Notice>(new BaseQueryInfo("View_File_User_Notice"),"ToUserID=@UserID AND IsRead=0", new SqlParameter("@UserID", uid));
        }

        public bool DeleteNotice(int noticeID)
        {
            return DeleteByKey(noticeID.ToString());
        }

        public bool DeleteNotice(int fromUID,int toUID,int fID)
        {
            string sql = "DELETE FROM [File_User_Notice] WHERE FromUserID=@FromUserID AND ToUserID=@ToUserID AND FileID=@FileID";
            return db.ExecuteNonQuery(sql,
                    new SqlParameter("@FromUserID",fromUID),
                    new SqlParameter("@ToUserID", toUID),
                    new SqlParameter("@FileID", fID)
                ) > 0;
        }

    }
}
