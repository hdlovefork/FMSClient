/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 12:34:52 
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
using System.Threading.Tasks;
using FileSystem.Entity;

namespace FileSystem.DAL
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        public override IQueryInfo QueryInfo {
            get
            {
                return new BaseQueryInfo("Position", new Relationship[] { new Relationship("User_Department_Position") });
            }
        }

        public List<Position> GetPositions()
        {
            return Find();
        }
    }
}
