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

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogEntity,BlogDto>();
            CreateMap<Post,PostDto>().ReverseMap();
            CreateMap<PostTag,PostTagDto>().ReverseMap();
            CreateMap<Post,PostDtoWithComments>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Tag,TagDto>().ReverseMap();
            CreateMap<Image,ImageDto>().ReverseMap();
        }
    }

}
