using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Repositories.Blogs
{
    public class BlogRepository : GenericRepository<BlogEntity, BloggingContext>, IBlogRepository
    {
        public BlogRepository(BloggingContext context) : base(context)
        {
        }

        public Task<BlogEntity> GetBlogByIdWithCategory(int id) {
            throw new NotImplementedException();
        }

        public async Task<BlogEntity> GetBlogByIdWithPostsAndComments(int id)
        {
            var blog = await _table.Where(b => b.Id == id).Include(b => b.Posts.Select(post => post.Comments)).FirstOrDefaultAsync();
            return blog;
        }

        public override IQueryable<BlogEntity> Sort(IQueryable<BlogEntity> blogs, int filter, bool order)
        {
            blogs = base.Sort(blogs, filter, order);

            if (order)
            {
                switch (filter)
                {
                    case 3:
                        {
                            return blogs.OrderByDescending(x => x.Title);
                        }
                    default:
                        {
                            return blogs;
                        }
                }

            }
            else
            {
                switch (filter)
                {
                    case 3:
                        {
                            return blogs.OrderBy(x => x.Title);
                        }
                    default:
                        {
                            return blogs;
                        }
                }
            }

        }
    }
}
