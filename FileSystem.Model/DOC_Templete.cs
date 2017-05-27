using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Model
{
    public class DOC_Templete
    {
        public int TempleteID { get; set; }

        public string TempleteName { get; set; }

        public int? TempleteType { get; set; }

        public string TempleteExt { get; set; }

        public byte[] TempleteData { get; set; }
    }
}
