using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Dal.Models;
using Blog.Dal.Models.Base;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Blogs
{
    public interface IBlogRepository : IGenericRepository<BlogEntity>
    {
        Task<BlogEntity> CreateBlogForUser(User user);
        Task<BlogEntity> GetBlogByIdWithPostsPaged(int id, int page);
    }
}