using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Categories;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Categories;

namespace Blog.Bll.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
      
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper){
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddCategoryAsync(string name)
        {
            Category category = new Category();

            category.SetModificationAndCreationTime();
            category.Name = name;

            category = await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            var categoryDto = _mapper.Map<Category,CategoryDto>(category);

            return categoryDto;
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int id)
        {
            Category category = await _categoryRepository.FindCategoryByIdWithBlogsPostsAndCommentsAsync(id);
            
            if(category == null){
                throw new ResourceNotFoundException("Category wtih id: "+ id + " not found");
            }

            category = _categoryRepository.Delete(category);

            await _categoryRepository.SaveAsync();

            CategoryDto deleted = _mapper.Map<Category,CategoryDto>(category);

            return deleted;
        }

  
        public async Task<CategoryDto> GetCategory(int id)
        {
           Category category = await _categoryRepository.FindByFirstAsync(cat => cat.Id == id);
            
            if(category == null){
                throw new ResourceNotFoundException("Category wtih id: "+ id + " not found");
            }

            var catDto = _mapper.Map<Category,CategoryDto>(category);

            return catDto;
        }
    }
}
