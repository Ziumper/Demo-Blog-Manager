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

        public async Task<BlogEntity> GetBlogByIdWithPostsAndComments(int id)
        {
            var blog = await _table.Where(b => b.Id == id).Include(b => b.Posts.Select(post => post.Comments)).FirstOrDefaultAsync();
            return blog;
        }

        public override IQueryable<BlogEntity> Sort(IQueryable<BlogEntity> blogs, int filter, bool order)
        {
            blogs = base.Sort(blogs, filter, order);
            blogs = blogs.Include(x => x.Category);

            if (order)
            {
                switch (filter)
                {
                    case 3:
                        {
                            return blogs.OrderByDescending(x => x.Title);
                        }
                    case 4:
                        {
                            return blogs.OrderByDescending(x => x.Category.Name);
                        }
                    case 5:
                        {
                            return blogs.OrderByDescending(x => x.IsActive);
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
                    case 4:
                        {
                            return blogs.OrderBy(x => x.Category.Name);
                        }
                    case 5:
                        {
                            return blogs.OrderBy(x => x.IsActive);
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
