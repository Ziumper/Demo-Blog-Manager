using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Dal.Repositories.Comments

{
    public class CommentRepository : GenericRepository<Comment, BloggingContext>, ICommentRepository
    {
        public CommentRepository(BloggingContext context) : base(context)
        {
        }

        public void DeleteManyCommentsByPostId(int postId)
        {
            var comments = FindBy(com => com.PostId == postId);
            foreach(var c in comments)
            {
                _table.Remove(c);
            }
        }
    }
}
