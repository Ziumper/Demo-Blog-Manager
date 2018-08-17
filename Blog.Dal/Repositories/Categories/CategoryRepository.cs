using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category, BloggingContext>, ICategoryRepository
    {
        protected CategoryRepository(BloggingContext context) : base(context)
        {
        }
    }
}
