/**************************************************************** 
 * 作    者：陶湘程
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 14:13:04 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FileSystem.Model;
using System.Data;
using PanGu;
using System.Data.SqlClient;
using System.Data.Common;

namespace FileSystem.Data.SqlServer
{
    public class FileService : BaseService<File>
    {
        /// <summary>
        /// 每个派生类必做
        /// </summary>
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("File"); }
        }

        //权限插入
        public bool AddPermission(int FileId, int FileRole)
        {
            string sql = string.Format("update [File] set FileRole='{0}' where FileId='{1}'",FileRole,FileId);
            return db.ExecuteNonQuery(sql,null)> 0;
        }

        public bool AddOtherPer(int FileId, int FileOther)
        {
            string sql = string.Format("update [File] set FileOther='{0}' where FileId='{1}'", FileOther, FileId);
            return db.ExecuteNonQuery(sql, null) > 0;
        
        }
        public IList<File> GetFilePersonlTree(int pid, int uid)
        {
            string condition = string.Format("FilePID={0} and UserId={2} and FileExt {1}", pid, "is null", uid);
            string sql = string.Format("select a.FileID,a.FileName,a.FileExt,a.FileSize,a.FileCreateTime from [File] a where {0}", condition);
            DataTable dt = db.ExecuteDataTable(sql, null);
            return ModelConvertHelper<File>.ConvertToModel(dt);
        }

        public DataTable GetFileByDepartment(int DepartmentId)
        {
            string sql = string.Format(@"select a.FileID,a.FileName,a.FileExt,a.FileSize,a.FileCreateTime,b.UserRealName from View_File_Department a
                                         inner join [User] b 
                                         on a.UserID = b.UserID
                                         where 1>0 
                                         and DepartmentID ={0} 
                                         and FileExt is not null ", DepartmentId);
            DataTable dt = db.ExecuteDataTable(sql, null);
            return dt;
        }

        public DataTable GetFileByUserId(int UserId)
        {
            string sql = string.Format(@"select FileID,FileName,FileExt,FileSize,FileCreateTime,UserRealName from View_File
                                         WHERE UserId ={0} 
                                         AND FileExt is not null", UserId);
            DataTable d = db.ExecuteDataTable(sql, null);
            return d;
        }

        //Add By 陶湘程加载文件列表
        public DataTable GetFileByUser(int UserId, int Pid)
        {
            string sql = string.Format(@"with FileTemp as 
                                        ( 
                                            select FileID,FileName,FileExt,FileSize,FileCreateTime,UserID from [File] where [File].FileID = {1} and [File].UserID={0}
                                            union all 
                                            select f.FileID,f.FileName,f.FileExt,f.FileSize,f.FileCreateTime,f.UserID from FileTemp
	                                        inner join [File] f on FileTemp.FileID = f.FilePID
                                        ) 
                                        select f.FileID,f.FileName,f.FileExt,f.FileSize,f.FileCreateTime,u.UserRealName from FileTemp f inner join [User] u
	                                        on f.UserID  = u.UserID where f.FileExt is not null",
                UserId, Pid);
            DataTable d = db.ExecuteDataTable(sql, null);
            return d;

        }

        //Add By 陶湘程查询文件
        public DataTable FindFile(ICollection<WordInfo> words)
        {
            string sql = @"select FileID,FileName,FileExt,FileSize,FileCreateTime,
                         UserRealName
                        from View_File 
                        where (";
            foreach (var p in words)
            {
                sql += string.Format("  FileName like  '%{0}%'  or", p.Word);
            }
            sql = sql.Remove(sql.Length - 2, 2);
            sql += string.Format(" ) and  FileExt  is  not null");
            return db.ExecuteDataTable(sql, null);

        }

        //Add By 陶湘程查询文件
        public DataTable SeniorFindFile(ICollection<WordInfo> words, string FileExt, string UserName, DateTime BTime, DateTime FTime)
        {
            string sql = "SELECT FileID,FileName,FileExt,FileSize,FileCreateTime,UserRealName from [View_File] ";
            if (words != null && words.Count > 0)
            {
                sql += "where(";
                foreach (var p in words)
                {
                    sql += string.Format("  FileName like  '%{0}%'  or", p.Word);
                }
                sql = sql.Remove(sql.Length - 2, 2) + ")";
            }
            else
            {
                sql += "where 1>0";
            }
            sql += string.Format(" and  FileExt  is  not null {0} {1} {2} {3} ",
                !string.IsNullOrEmpty(FileExt.Trim()) ? "and FileExt like '%" + FileExt + "%'" : "",
                !string.IsNullOrEmpty(UserName.Trim()) ? "and (UserRealName like '%" + UserName + "%' or UserName like '%" + UserName + "%')" : "",
                !string.IsNullOrEmpty(BTime.ToString()) ? "and UserCreateTime >= '" + BTime + "'" : "",
                !string.IsNullOrEmpty(FTime.ToString()) ? "and UserCreateTime <= '" + FTime + "'" : ""
                );
            return db.ExecuteDataTable(sql, null);
        }

        public bool AddFile(File file)
        {
            return base.Insert(file);
        }

        public int MaxId()
        {
            string sql = "select max(FileID) from [File]";
            return Convert.ToInt32(db.ExecuteDataTable(sql, null).Rows[0][0]);
        }

        public List<File> GetOne(int fileId)
        {
            return base.FindById(fileId);
        }

        public bool Delete(int fileId)
        {
            Dictionary<string, DbParameter[]> dic = new Dictionary<string, DbParameter[]>();
            dic.Add("delete from ACL_File_User where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from ACL_File_Department where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from Comment where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from [File_User_Notice] where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from [File] where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });

            int i = db.ExecuteNonQuery(dic);
            return i > 0 ? true : false;
        }

        public bool UpdateFileArchive(int fileId, bool status)
        {
            string strSql = "update [File] set FileArchive=@FileArchive where FileID=@FileID";
            int i = db.ExecuteNonQuery(strSql, new SqlParameter[]{
                new SqlParameter("@FileArchive", status),
                new SqlParameter("@FileID", fileId),
            });
            return i > 0 ? true : false;
        }

        public IList<File> GetCatalogTree(int pid, int UserId)
        {
            string condition = string.Format("FilePID={0} and UserId={2} and FileExt {1}", pid, "is null", UserId);
            string sql = string.Format("select a.FileID,a.FileName,a.FileExt,a.FileSize,a.FileCreateTime from [File] a where {0}", condition);
            DataTable dt = db.ExecuteDataTable(sql, null);
            return ModelConvertHelper<File>.ConvertToModel(dt);
        }


        public bool AddCatalogFile(File file)
        {
            string sql = string.Format("insert into [File](FileName,FileSize,FilePID,UserID) values(@FileName,@FileSize,@FilePID,@UserID)");
            return db.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("@FileName",file.FileName),
                new SqlParameter("@FileSize",file.FileSize),
                new SqlParameter("@FilePID",file.FilePID),
                new SqlParameter("@UserID",file.UserID),
            }) > 0;
        }

        public bool DeleteCatalog(int fileId)
        {
            Dictionary<string, DbParameter[]> dic = new Dictionary<string, DbParameter[]>();
            dic.Add("delete from ACL_File_User where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from ACL_File_Department where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from Comment where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            dic.Add("delete from [File] where FileID=@FileID", new SqlParameter[] { new SqlParameter("@FileID", fileId) });
            return db.ExecuteNonQuery(dic) > 0;
        }

        public bool UpdateCatalog(string BFileName, string LFileName)
        {
            //string sql = string.Format("update  [File]  set FileName='{0}' where FileName='{1}'",BFileName,LFileName);
            Dictionary<string, DbParameter[]> dic = new Dictionary<string, DbParameter[]>();
            dic.Add("update  [File]  set FileName=@BFileName where FileName=@LFileName", new SqlParameter[] { new SqlParameter("@BFileName", BFileName), new SqlParameter("@LFileName", LFileName) });
            return db.ExecuteNonQuery(dic) > 0;
        }

        public bool UpdateCatelog(File file)
        {
            string sql = "UPDATE [File] SET FileName=@FileName WHERE FileID=@FileID";
            return db.ExecuteNonQuery(sql, new SqlParameter("@FileID", file.FileID),
                new SqlParameter("@FileName", file.FileName)
                ) > 0;
        }

        public List<File_Department> GetDepByFID(int fid)
        {
           return Find<File_Department>(new BaseQueryInfo("View_File_Department","", false, "*", "FileID"), "FileID=@FileID", new SqlParameter("@FileID", fid));
        }

        public List<ACL_File_User> GetUsersByFID(int fid)
        {
            return Find<ACL_File_User>(new BaseQueryInfo("View_File_User","",false,"*","FileID"), "FileID=@FileID", new SqlParameter("@FileID", fid));
        }

       
    }
}
