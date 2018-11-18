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

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<CategoryDto,Category>(categoryDto);
            category.Blogs = new List<BlogEntity>();

            category = await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            CategoryDto result = _mapper.Map<Category,CategoryDto>(category);

            return result;
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int id)
        {
            Category category = await _categoryRepository.FindByFirstAsync( cat => cat.Id == id);
            
            if(category == null){
                throw new ResourceNotFoundException("Category wtih id: "+ id + " not found");
            }

            category = _categoryRepository.Delete(category);

            await _categoryRepository.SaveAsync();

            CategoryDto deleted = _mapper.Map<Category,CategoryDto>(category);

            return deleted;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            List<Category> categories = await _categoryRepository.GetAllAsync();
            
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                var categoryDto = _mapper.Map<Category,CategoryDto> (category);
                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
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

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto category)
        {
            var categoryEntity = await _categoryRepository.FindByFirstAsync(cat => cat.Id == category.Id);
            if(categoryEntity == null)
            {
                var message = "Category with id " + category.Id + "not found";
                throw new ResourceNotFoundException(message);
            }
            
            categoryEntity = _categoryRepository.Edit(categoryEntity);
            await _categoryRepository.SaveAsync();

            var result = _mapper.Map<Category,CategoryDto>(categoryEntity);
            return result;
        }
    }
}
