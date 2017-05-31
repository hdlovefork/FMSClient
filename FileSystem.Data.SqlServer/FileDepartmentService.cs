using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using System.Data.SqlClient;

namespace FileSystem.Data.SqlServer
{
    public class FileDepartmentService : BaseService<File_Department>
    {
        /// <summary>
        /// 每个派生类必做
        /// </summary>
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("ACL_File_Department"); }
        }
       
        public bool InsertFileDepartment(File_Department acl)
        {
            string sql = "INSERT INTO ACL_File_Department (FileID,DepartmentID,FilePermission) VALUES (@FileID,@DepartmentID,@FilePermission)";
            return db.ExecuteNonQuery(sql,
                new SqlParameter("@FileID", acl.FileID),
                new SqlParameter("@DepartmentID", acl.DepartmentID),
                new SqlParameter("@FilePermission", acl.FilePermission)
                ) > 0;
        }

        public bool UpdateFileDepartment(File_Department acl)
        {
            string sql = "UPDATE ACL_File_Department SET FilePermission=@FilePermission WHERE DepartmentID=@DepartmentID AND FileID=@FileID";
            return db.ExecuteNonQuery(sql,
                new SqlParameter("@FileID", acl.FileID),
                new SqlParameter("@DepartmentID", acl.DepartmentID),
                new SqlParameter("@FilePermission", acl.FilePermission)
                ) > 0;
        }

        public bool DeleteFileDepartment(File_Department acl)
        {
            string sql = "DELETE FROM ACL_File_Department WHERE DepartmentID=@DepartmentID AND FileID=@FileID";
            return db.ExecuteNonQuery(sql,
                new SqlParameter("@FileID", acl.FileID),
                new SqlParameter("@DepartmentID", acl.DepartmentID)
                ) > 0;
        }
    }
}
