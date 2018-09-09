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
        Task<BlogEntity> GetBlogByIdWithPosts(int id);
        Task<PagedEntity<BlogEntity>> GetAllBlogsPagedAndFilteredByOrder(int page,int size,int filter,bool order,Expression<Func<BlogEntity,bool>> predicate = null);
    }
}