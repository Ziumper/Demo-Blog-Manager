using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Blogs;
using Blog.Bll.Exceptions;
using Blog.Bll.Dto.QueryModels;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;

namespace Blog.Bll.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, 
        IMapper mapper,
        ICommentRepository commentRepositry, 
        IPostRepository postRepository
        )
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _commentRepository = commentRepositry;
            _postRepository = postRepository;
        }

        public async Task<BlogDto> AddBlogAsync(BlogDto blog)
        {
            /* 
            var category = await _categoryRepository.FindCategoryByNameWithBlogsAsync(blog.Category.Name);
            if(category == null)
            {
                throw new ResourceNotFoundException("Category with id " + blog.Category.Name + " not found" );
            }  
            */
            var blogEntity = _mapper.Map<BlogDto,BlogEntity>(blog);
            //blogEntity.Category = category;

            var result = await _blogRepository.AddAsync(blogEntity);

            await _blogRepository.SaveAsync();

            var resultDto = _mapper.Map<BlogEntity,BlogDto> (result);

            return resultDto;
        }

        public async Task<BlogDto> DeleteBlogAsyncById(int id)
        {
            var blog = await _blogRepository.GetBlogByIdWithPostsAndComments(id);
            if(blog == null) throw new ResourceNotFoundException("Blog with Id" + id + " is not found");

            var result = _blogRepository.Delete(blog);

             await _blogRepository.SaveAsync();

            var resultDto = _mapper.Map<BlogEntity,BlogDto> (result);

            return resultDto;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            var blogsDto = new List<BlogDto>();

            foreach(var blog in blogs)
            {
                blogsDto.Add(_mapper.Map<BlogEntity,BlogDto>(blog));
            }

            return blogsDto;
        }

        public async Task<BlogDtoPaged> GetAllBlogsPaged(int page, int size)
        {
            var result = await _blogRepository.GetAllPagedAsync(page,size);
            var blogs = result.Entities;
            return new BlogDtoPaged(_mapper,result,page,size);
        }

        public async Task<BlogDtoPaged> GetAllBlogsPaged(BlogQuery query)
        {
            var result = await _blogRepository.GetAllPagedAsync(
                query.Page,query.Size,query.Filter,query.Order, b => b.Title.Contains(query.SearchQuery) 
                );
            
            var entities = result.Entities.AsQueryable();
            result.Entities =_blogRepository.Sort(entities,query.Filter,query.Order).ToList();

            return new BlogDtoPaged(_mapper,result,query.Page,query.Size);
        }


        public async Task<BlogDto> GetBlogByIdAsync(int id)
        {
            var blog = await _blogRepository.GetBlogByIdWithCategory(id);
            if(blog == null) throw new ResourceNotFoundException("Blog with Id " + id + " not found");
            var blogDto = _mapper.Map<BlogEntity,BlogDto>(blog);
            return blogDto;
        }

        public async Task<IEnumerable<BlogDto>> GetBlogByTitleAsync(string title)
        {
            var blogs = await _blogRepository.FindByAsync(b => b.Title.Contains(title));
            var blogsDto = new List<BlogDto>();

            foreach (var item in blogs)
            {
                var blogDto = _mapper.Map<BlogEntity,BlogDto>(item);
                blogsDto.Add(blogDto);
            }
            
            return blogsDto;
        }

        public async Task<BlogDto> UpdateBlogAsync(BlogDto blog)
        {
            var result = await _blogRepository.FindByFirstAsync(b => b.Id == blog.Id);

            if(result == null) throw new ResourceNotFoundException("Blog with Id " + blog.Id + "not found");

            result.Title = blog.Title;

            result =  _blogRepository.Edit(result);

            await _blogRepository.SaveAsync();

            return _mapper.Map<BlogEntity,BlogDto>(result);
        }

       
    }
}
