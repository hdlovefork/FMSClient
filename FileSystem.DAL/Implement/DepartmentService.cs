/**************************************************************** 
 * 作    者：黄鼎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-12 11:52:57 
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
using System.Data.Common;

namespace FileSystem.DAL
{
    public class DepartmentService : BaseService<Department>, IDeapartService
    {
        //public override IQueryInfo QueryInfo => new BaseQueryInfo("Department");

        public override IQueryInfo QueryInfo
        {
            get { return new BaseQueryInfo("Department",
                                            new Relationship[] { new Relationship("User_Department_Position")
                                                                }
                                            );
                }
        }

        public List<Department> GetDepartments()
        {
            string sql = "SELECT * FROM [View_Department_Position]";
            DbDataReader reader = _db.ExecuteReader(sql, null);
            int lastDepID = 0;
            List<Department> list = new List<Department>();
            Department dep = null;
            while (reader.Read())
            {
                int curDepID = Convert.ToInt32(reader["DepartmentID"]);
                if (curDepID != lastDepID)
                {
                    lastDepID = curDepID;
                    dep = new Department();
                    dep.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    dep.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    list.Add(dep);
                }
                Position pos = new Position
                {
                    PositionID = Convert.ToInt32(reader["PositionID"]),
                    PositionName = Convert.ToString(reader["PositionName"])
                };
                dep.Positions.Add(pos);
            }
            reader.Close();
            return list;
        }

        public List<Department> GetDepartmentsByUID(int uid)
        {
            throw new NotImplementedException();
        }
    }
}
