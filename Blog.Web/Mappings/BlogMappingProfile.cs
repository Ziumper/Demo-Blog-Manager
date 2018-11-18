using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.Categories;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<BlogEntity,BlogDto>().ReverseMap();
            CreateMap<Post,PostCreateDto>().ReverseMap();
            CreateMap<Post,PostDto>().ReverseMap();
        }
    }

}
