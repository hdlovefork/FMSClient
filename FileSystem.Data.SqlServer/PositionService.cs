/**************************************************************** 
 * 作    者：费彬彬
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

namespace FileSystem.Data.SqlServer
{
   public class PositionService:BaseService<Position>
    {
       public override IQueryInfo QueryInfo
       {
           get { return new BaseQueryInfo("Position"); }
       }
       public List<Position> GetPositionTree() {
           List<Position> p = base.Find();

           return p;
       }

       public  IList<User> GetUserByPositionId(int PositionId) {
           String sql = string.Format(@"select * from [User] u where u.UserID in  (
                                        select DISTINCT UserID from [dbo].[View_User_Department_Position]
	                                    where positionID =  {0})",PositionId);
           DataTable dt = db.ExecuteDataTable(sql, null);
           IList<User> lst = ModelConvertHelper<User>.ConvertToModel(dt);
           return lst;
       }
    }
}
