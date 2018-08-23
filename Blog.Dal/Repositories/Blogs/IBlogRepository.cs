﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Blogs
{
    public interface IBlogRepository : IGenericRepository<BlogEntity>
    {
        Task<IAsyncEnumerable<BlogEntity>> GetAllBlogsAsync();
    }
}