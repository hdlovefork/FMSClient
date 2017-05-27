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
using System.Linq;
using System.Text;
using FileSystem.Model;
using System.Data;

namespace FileSystem.Data.SqlServer
{
    public class DOCTempleteService : BaseService<DOC_Templete>
    {
        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("DOC_Templete", "TempleteID"); }
        }

        public DataTable GetTempleteByType(int type) {
            string sql = "select TempleteID,TempleteName,TempleteType from DOC_Templete where TempleteType=" + type;
            DataTable dt = db.ExecuteDataTable(sql, null);
            return dt;
        }

        public List<DOC_Templete> GetOne(int id) {
            return base.FindById(id);
        }
    }
}
