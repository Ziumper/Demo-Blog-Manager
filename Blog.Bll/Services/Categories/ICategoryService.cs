using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Bll.Dto.Categories;

namespace Blog.Bll.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddCategoryAsync(string name);
        Task<CategoryDto> DeleteCategoryAsync(int id);
        Task<CategoryDto> GetCategory(int id);
        
    }
}