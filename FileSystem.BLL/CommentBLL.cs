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
using System.Text;
using FileSystem.Data.SqlServer;
using System.Data;
using FileSystem.Model;

namespace FileSystem.BLL
{
   public class CommentBLL
    {
       public int InsertComment(int userId, int fileId, string commentMsg)
       {

           return new CommentService().InsertComment(new Comment() { 
               FileId = fileId,
               UserId = userId,
               CommentMsg = commentMsg,
               CommentCreateTime = DateTime.Now
           });
       
       }

       public DataTable FindComment(int FileId)
       {
           return new CommentService().FindComment(FileId);
       
       }
    }
}
