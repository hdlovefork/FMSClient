using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Model;
using FileSystem.Data.SqlServer;
using System.Data;

namespace FileSystem.BLL
{
    public class DOCTempleteBLL
    {
        public DataTable GetTempleteByType(int type)
        {
            return new DOCTempleteService().GetTempleteByType(type);
        }

        public List<DOC_Templete> GetOne(int id) {
            return new DOCTempleteService().GetOne(id);
        }
    }
}
