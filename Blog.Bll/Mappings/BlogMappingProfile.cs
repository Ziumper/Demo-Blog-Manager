using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Dal.Models;

namespace Blog.Bll.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostDtoWithComments>();
            CreateMap<PostCreateDto, Post>().ForMember(post => post.PostId , postDto => postDto.Ignore());

            CreateMap<CommentCreateDto,Comment>().ForMember(comment => comment.CommentId , commentDto => commentDto.Ignore()) ;
            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<BlogEntity, BlogDto>().ReverseMap();
            CreateMap<BlogCreateDto,BlogEntity>().ForMember(o => o.Posts,opt => opt.Ignore())
            .ForMember(o => o.BlogEntityId,opt => opt.Ignore());

              
        }
    }

}
