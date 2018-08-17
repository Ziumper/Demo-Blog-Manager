using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;

namespace Blog.Bll.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

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
    }
}
