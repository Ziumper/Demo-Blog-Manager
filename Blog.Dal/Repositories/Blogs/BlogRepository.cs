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

        public async Task<BlogEntity> GetBlogByIdWithPosts(int id)
        {
            var blog = await _table.Where(b => b.BlogEntityId == id).Include(b => b.Posts).FirstAsync();
            return blog;
        }
    }
}
