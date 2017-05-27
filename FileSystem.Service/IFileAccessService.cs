/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-16 20:37:22 
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Service
{
    internal interface IFileAccessService:IService
    {
        /// <summary>
        /// 获得指定ID的文件信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        File GetFileByFID(int fileID);
    }
}
