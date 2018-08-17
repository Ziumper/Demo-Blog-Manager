using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Comments
{
    public interface ICommentRepository : IGenericRepository<Comment> 
    {
        void DeleteManyCommentsByPostId(int postId);
    }
}
