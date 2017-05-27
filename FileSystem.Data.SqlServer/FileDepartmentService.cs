using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;

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
        public bool Add(File_Department acl) {
            return base.Insert(acl);
        }
    }
}
