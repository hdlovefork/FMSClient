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
using FileSystem.Data.SqlServer;
using System.Windows.Forms;
using System.Data;
using PanGu;

namespace FileSystem.BLL
{
    public class FileBLL
    {
        //权限插入
        public bool AddPermission(int FileId, int FileRole)
        {
            return new FileService().AddPermission(FileId, FileRole);
        }
        public bool AddOtherPer(int FileId, int FileOther)
        {
            return new FileService().AddOtherPer(FileId, FileOther);
        }
        public bool UpdateFileArchive(int fileId, bool status)
        {
            return new FileService().UpdateFileArchive(fileId, status);
        }

        public int AddFileDep(File file, int depID)
        {
            int fid = 0;
            //添加新文件
            bool ok = new FileService().AddFile(file);
            if (ok)
            {
                fid = MaxId();
                if (fid <= 0) return fid;
                //将新文件添加到文件-部门中间表
                ok = new FileDepartmentBLL().AddFilDepartment(
                          new File_Department
                          {
                              FileID = fid,
                              DepartmentID = depID,
                              FilePermission=1
                          }
                          );
            }
            return fid;
        }

        public List<File> GetOne(int fileId)
        {
            return new FileService().GetOne(fileId);
        }

        public IList<File> GetFilePersonlTree(int pid, int uid)
        {
            return new FileService().GetFilePersonlTree(pid, uid);
        }
        public DataTable GetFileByDepartment(int DepartmentId)
        {
            return new FileService().GetFileByDepartment(DepartmentId);

        }
        public DataTable GetFileByUserId(int UserId)
        {
            return new FileService().GetFileByUserId(UserId);
        }

        public DataTable GetFileByUser(int UserId, int Pid)
        {
            return new FileService().GetFileByUser(UserId, Pid);
        }

        public DataTable FindFile(ICollection<WordInfo> words)
        {
            return new FileService().FindFile(words);

        }

        public DataTable SeniorFindFile(ICollection<WordInfo> words, string FileExt, string UserName, DateTime BTime, DateTime FTime)
        {
            return new FileService().SeniorFindFile(words, FileExt, UserName, BTime, FTime);

        }

        public bool AddFile(File file)
        {
            return new FileService().AddFile(file);
        }

        public int MaxId()
        {
            return new FileService().MaxId();
        }

        public bool Delete(int fileId)
        {
            return new FileService().Delete(fileId);
        }

        public IList<File> GetCatalogTree(int pid, int UserId)
        {
            return new FileService().GetCatalogTree(pid, UserId);
        }
        public bool AddCatalogFile(File file)
        {
            return new FileService().AddCatalogFile(file);
        }
        public bool DeleteCatalog(int fileId)
        {
            return new FileService().DeleteCatalog(fileId);

        }
        public bool UpdateCatalog(string BFileName, string LFileName)
        {
            return new FileService().UpdateCatalog(BFileName, LFileName);
        }

        public List<File_Department> GetDepShareFiles(int fileID)
        {
            return new FileService().GetDepByFID(fileID);
        }

        public List<ACL_File_User> GetUserShareFiles(int fileID)
        {
            return new FileService().GetUsersByFID(fileID);
        }
    }
}
