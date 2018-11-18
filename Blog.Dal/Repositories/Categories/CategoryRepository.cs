using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category, BloggingContext>, ICategoryRepository
    {
        public CategoryRepository(BloggingContext context) : base(context)
        {
        }

        public async Task<Category> FindCategoryByIdWithBlogsAsync(int id)
        {
            var category = await _table.Where(cat => cat.Id == id)
            .Include(cat => cat.Blogs)
            .FirstOrDefaultAsync();
            return category;
        }

        public async Task<Category> FindCategoryByNameWithBlogsAsync(string name)
        {
            var category = await _table.Where(cat => cat.Name.Equals(name)).Include(cat => cat.Blogs).FirstOrDefaultAsync();
            return category;
        }

      
    }
}
