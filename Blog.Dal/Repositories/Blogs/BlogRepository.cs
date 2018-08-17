using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Blogs
{
    public class BlogRepository : GenericRepository<BlogEntity, BloggingContext>, IBlogRepository
    {
        protected BlogRepository(BloggingContext context) : base(context)
        {
        }
    }
}
