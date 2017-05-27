using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Entity
{
    class UserRole:BaseEntity
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
