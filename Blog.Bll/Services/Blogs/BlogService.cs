using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;

namespace Blog.Bll.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public List<BlogDto> GetAllBlogs()
        {
            var blogs = _blogRepository.GetAll();
            List<BlogDto> blogDtos = new List<BlogDto>();
            foreach(var blog in blogs)
            {
                blogDtos.Add(_mapper.Map<BlogEntity,BlogDto>(blog));
            }

            return blogDtos;
        }

        public BlogDto GetBlogById(int id)
        {
            var blog = _blogRepository.FindByFirst(x => x.BlogEntityId == id);
            if(blog == null) throw new ResourceNotFoundException("Blog with id" + id + " not found");
            var blogDto = _mapper.Map<BlogEntity,BlogDto>(blog);

            return blogDto;
        }
    }
}
