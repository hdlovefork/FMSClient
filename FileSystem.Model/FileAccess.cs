using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public enum FileAccess
    {
        /// <summary>
        /// （可读）0000 0001
        /// </summary>
        Read = 0x1,
        /// <summary>
        /// （可写）0000 0010
        /// </summary>
        Write = 0x2,
        /// <summary>
        /// （读写）0000 0100
        /// </summary>
        ReadAndWrite = 0x3,
        /// <summary>
        /// （删除）0000 1000
        /// </summary>
        Delete = 0x4,
        /// <summary>
        /// 0001 0000
        /// </summary>
        Download = 0x8,
        /// <summary>
        /// 0010 0000
        /// </summary>
        Upload = 0x10,
        /// <summary>
        /// 0100 0000
        /// </summary>
        Archives = 0x20,
        /// <summary>
        /// 1000 0000
        /// </summary>
        Share = 0x40,
    }
}
