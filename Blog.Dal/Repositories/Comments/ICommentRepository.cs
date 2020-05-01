using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Comments
{
    public interface ICommentRepository : IGenericRepository<Comment> 
    {
        void DeleteManyCommentsByPostId(int postId);
        Task<List<Comment>> GetCommentsByPostId(int postId,int skip,int take);
        Task<int> GetCommentsCountByPostId(int postId);
    }
}
