using System;
using System.Collections.Generic;
using System.Text;
using FileSystem.Model;
namespace FileSystem.Data.SqlServer
{
    /// <summary>
    /// 文件操作接口类
    /// </summary>
    public  interface IFileService
    {
        /// <summary>
        /// 获取部门下的文件
        /// </summary>
        /// <param name="depId">部门编号</param>
        /// <returns>得到一组文件</returns>
        List<File> GetFilesByDepId(int depId);

        /// <summary>
        /// 根据文件标号获取文件
        /// </summary>
        /// <param name="fileId">文件编号</param>
        /// <returns></returns>
        File GetFileById(int fileId);

        /// <summary>
        /// 根据文件编号获取用户信息
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        List<User> GetUserByFileID(int fileID);

        /// <summary>
        /// 根据岗位
        /// </summary>
        /// <param name="positionID"></param>
        /// <returns></returns>
        List<File> GetFilesByDepIDAndPosID(int depID,int posID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        bool DeleteFileByID(int fileID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool InsertFile(File file);
    }    
}
