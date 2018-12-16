using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.Categories;
using Blog.Bll.Dto.Comments;
using Blog.Bll.Dto.Tags;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Category,CategoryDtoWithPosts>();
            CreateMap<BlogEntity,BlogDto>();
            CreateMap<BlogDto,BlogEntity>().ForMember( x => x.Category, opt => opt.Ignore());
            CreateMap<Post,PostDto>().ReverseMap();
            CreateMap<Post,PostDtoWithComments>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Tag,TagDto>().ReverseMap();
        }
    }

}
