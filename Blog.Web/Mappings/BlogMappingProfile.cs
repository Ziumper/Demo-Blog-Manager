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
using Blog.Bll.Dto.Images;
using Blog.Bll.Dto.Users;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogEntity,BlogDto>();
            CreateMap<Post,PostDto>().ReverseMap();
            CreateMap<Post,PostDtoWithComments>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Image,ImageDto>().ReverseMap();
            CreateMap<UserDto,User>();
            CreateMap<User,UserDtoWithoutPassword>();
        }
    }

}
