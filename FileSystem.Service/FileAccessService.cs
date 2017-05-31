/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-16 20:36:48 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using FileSystem.DAL;
using FileSystem.Entity;
using FileSystem.Service.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FileSystem.Service
{
    public class FileAccessService : BaseService<File>, IFileAccessService
    {
        public override IQueryInfo QueryInfo { 
            get { return new BaseQueryInfo("File", null); } 
        }

        public File GetFileByFID(int fileID)
        {
            return FindSingle("FileID=@FileID", new SqlParameter("@FileID", fileID));
        }

        public List<FileDepartment> GetDepartmentByFID(int fileID){
           return Find<FileDepartment>(new BaseQueryInfo("View_File_Department",null),"FileID=@FileID",new SqlParameter("@FileID",fileID));
        }

        public List<Department> GetDepartmentByUID(int uid)
        {
            return Find<Department>(new BaseQueryInfo("View_User_Department_Position", null), "UserID=@UserID", new SqlParameter("@UserID", uid));
        }

        public FileUser GetFileShare(int uid,int fileID)
        {
            return FindSingle<FileUser>(new BaseQueryInfo("ACL_File_User",null),"UserID=@UserID AND FileID=@FileID", new SqlParameter("@UserID", uid), new SqlParameter("@FileID", fileID));
        }     

        internal bool IsShareFile(int uid, int fileID)
        {
            List<DbParameter> list = new List<DbParameter> {
                new SqlParameter("@UserID",uid),
                new SqlParameter("FileID",fileID)
            };
            object r = _db.ExecuteScalar("SELECT COUNT(FileID) FROM [File_Share] WHERE FileID=@FileID AND UserID=@UserID", list);
            if (r is DBNull) return false;
            if (r == null) return false;
            int count;
            if (int.TryParse(r.ToString(), out count))
                return count > 0;
            return false;
        }
    }

}
