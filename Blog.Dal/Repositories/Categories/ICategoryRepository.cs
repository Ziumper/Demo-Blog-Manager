using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> FindCategoryByIdWithBlogsPostsAndCommentsAsync(int id);
        Task<List<Category>> GetCategoriesWithPostsAsync();
    }
}