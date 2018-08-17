using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Blogs
{
    public interface IBlogRepository : IGenericRepository<BlogEntity>
    {
    }
}