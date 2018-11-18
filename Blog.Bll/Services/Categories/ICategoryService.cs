using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Bll.Dto.Categories;

namespace Blog.Bll.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddCategoryAsync(CategoryDto category);
        Task<CategoryDto> UpdateCategoryAsync(CategoryDto category);
        Task<CategoryDto> DeleteCategoryAsync(int id);
        Task<CategoryDto> GetCategory(int id);
        Task<List<CategoryDto>> GetCategoriesAsync();
    }
}