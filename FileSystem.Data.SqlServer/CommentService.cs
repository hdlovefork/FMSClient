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
using FileSystem.Model;
using System.Data;
using System.Data.SqlClient;

namespace FileSystem.Data.SqlServer
{
   public class CommentService:BaseService<Comment>
    {
       public override IQueryInfo QueryInfo
       {
           get { return new BaseQueryInfo("Comment"); }
       }

       public int InsertComment(Comment comment) {
           string sql = string.Format("insert into Comment(FileId,UserId,CommentMsg,CommentCreateTime) values(@FileId,@UserId,@CommentMsg,@CommentCreateTime)");
          int a= db.ExecuteNonQuery(sql,new SqlParameter[]{
                                        new SqlParameter("@FileId",comment.FileId),
                                        new SqlParameter("@UserId",comment.UserId),
                                        new SqlParameter("@CommentMsg",comment.CommentMsg),
                                        new SqlParameter("@CommentCreateTime",comment.CommentCreateTime)
          });
          return a;
       }

       public DataTable FindComment(int FileId) {
           string sql = string.Format("select (select UserRealName from [User] where UserID = a.UserID) as UserRealName, CommentCreateTime,CommentMsg from Comment a where FileId={0}", FileId);
           DataTable dt = db.ExecuteDataTable(sql, null);
           return dt;
       }
    }
}
