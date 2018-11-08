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
        protected CategoryRepository(BloggingContext context) : base(context)
        {
        }

        public async Task<Category> FindCategoryByIdWithBlogsPostsAndCommentsAsync(int id)
        {
            var category = await _table.Where(cat => cat.Id == id)
            .Include(cat => cat.Blogs)
            .ThenInclude(blog => blog.Posts)
            .ThenInclude(post => post.Comments)
            .FirstOrDefaultAsync();
            return category;
        }

        public Task<List<Category>> GetCategoriesWithPostsAsync()
        {
            var category = _table.Include(cat => cat.Blogs).ThenInclude(blog => blog.Posts);
            
            throw new NotImplementedException();
        }
    }
}
