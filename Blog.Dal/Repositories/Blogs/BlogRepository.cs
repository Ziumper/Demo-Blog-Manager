using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;



namespace Blog.Dal.Repositories.Blogs
{
    public class BlogRepository : GenericRepository<BlogEntity, BloggingContext>, IBlogRepository
    {
        protected BlogRepository(BloggingContext context) : base(context)
        {
        }

        public async Task<IAsyncEnumerable<BlogEntity>> GetAllBlogsAsync()
        {
            var result = await _table.ToListAsync();
            return result.ToAsyncEnumerable();
        }
    }
}
