﻿/**************************************************************** 
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

namespace FileSystem.Data.SqlServer
{
    public class AuthAccessService:BaseService<File>
    {
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("Comment"); }
        }

        public bool Auth(int uid, File file, FileAccess access)
        {
            return false;
        }



        
    }
}
