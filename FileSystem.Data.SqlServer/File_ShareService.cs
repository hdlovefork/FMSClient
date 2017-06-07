using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace FileSystem.Data.SqlServer
{
    public class File_ShareService : BaseService<File_Share>
    {
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("File_Share"); }
        }
        public bool AddFile_Share(int FileId,int UserId) {
            string sql = string.Format("insert into [ACL_File_User](FileID,UserID) values(@FileID,@UserID)");
            return db.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("@FileID",FileId),
                new SqlParameter("@UserID",UserId)
            }) > 0;
        
        }

        public DataTable GetFile_Share(int UserId) {
            string sql = string.Format(@"select FileID,FileName,FileExt,FileSize,FileCreateTime,OwnerRealName as UserRealName from [View_File_User] 
	                                    where UserID={0} and FileExt is not null" ,UserId);
            DataTable d = db.ExecuteDataTable(sql, null);
            return d;
        }

        public bool AddFile_Dep(int FileId, int DepID)
        {
            string sql = string.Format("insert into [ACL_File_Department](FileID,DepartmentID) values(@FileID,@DepartmentID)");
            return db.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("@FileID",FileId),
                new SqlParameter("@DepartmentID",DepID)
            }) > 0;

        }
    }
}
