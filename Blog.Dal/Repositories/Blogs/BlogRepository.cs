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
        private protected int _postsForPage;

        public BlogRepository(BloggingContext context) : base(context)
        {
            _postsForPage = 10;
        }

        public async Task<BlogEntity> CreateBlogForUser(User user)
        {
            BlogEntity blogEntity = new BlogEntity();
            blogEntity.User = user;
            blogEntity = await this.AddAsync(blogEntity);
            await this.SaveAsync();   

            return blogEntity;
        }


        public Task<BlogEntity> GetBlogByIdWithPostsAndCommentsPaged(int id, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogEntity> GetBlogByIdWithPostsPaged(int id, int page)
        {
            var skipCount = GetSkipCount(page,_postsForPage);
            var blog = await  _table.Where(b => b.Id == id).Include(b=>b.Posts.Skip(skipCount).Take(_postsForPage)).FirstOrDefaultAsync();
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
