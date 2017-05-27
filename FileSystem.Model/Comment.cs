using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public int FileId { get; set; }
        public int UserId { get; set; }
        public DateTime CommentCreateTime { get; set; }
        public string CommentMsg { get; set; }
    }
}
