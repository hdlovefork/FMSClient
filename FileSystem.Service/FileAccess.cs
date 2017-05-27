/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-16 10:44:36 
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
using System.Linq;
using System.Text;

namespace FileSystem.Service
{
    /// <summary>
    /// 对文件的操作动作
    /// </summary>
    public enum FilePermission
    {
        /// <summary>
        /// 可读 0000 0001
        /// </summary>
        Read=0x1,
        /// <summary>
        /// 可写 0000 0010
        /// </summary>
        Write=0x2,
        /// <summary>
        /// 可读写 0000 0100
        /// </summary>
        ReadAndWrite=0x3,
        /// <summary>
        /// 可上传 0000 1000
        /// </summary>
        Upload=0x4,
        /// <summary>
        /// 可下载 0001 0000
        /// </summary>
        Download = 0x8,
        /// <summary>
        /// 可归档 0010 0000
        /// </summary>
        Archive = 0x10,
        /// <summary>
        /// 可共享 0100 0000
        /// </summary>
        Share = 0x20,
        /// <summary>
        /// 可删除 1000 0000
        /// </summary>
        Delete = 0x40,  
    }
}
