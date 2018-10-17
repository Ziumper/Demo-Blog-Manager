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
            .Include(cat => cat.Blogs
                .Select(posts => posts.Posts
                    .Select(comment => comment.Comments)))
            .FirstOrDefaultAsync();
            return category;
        }
    }
}
