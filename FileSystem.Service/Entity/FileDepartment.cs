/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-27 19:01:17 
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

namespace FileSystem.Service.Entity
{
    public class FileDepartment:BasePermission
    {
        public int DepartmentID { get; set; }
        public int FileID { get; set; }
        public int UserID { get; set; }
    }
}
