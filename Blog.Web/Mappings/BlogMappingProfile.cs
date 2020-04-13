using AutoMapper;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.Comments;
using Blog.Bll.Dto.Users;
using Blog.Dal.Models.Posts;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogEntity,BlogDto>();
            CreateMap<Post,PostDto>().ReverseMap();
            CreateMap<PostWithAuthor,PostDtoWithAuthor>().ReverseMap();
            CreateMap<PostWithComments,PostDtoWithComments>()
            .ForMember(post => post.BlogTitle, opt => opt.MapFrom(post => post.Blog.Title))
            .ReverseMap();
            CreateMap<Post,PostDtoWithComments>().ReverseMap();
            CreateMap<Comment,CommentDto>();
            CreateMap<CommentCreateDto,Comment>()
            .ForMember(comment => comment.Post, option => option.Ignore());
            CreateMap<BlogDto,BlogEntity>()
                .ForMember(b => b.Posts,opt => opt.Ignore());
            CreateMappingsForUserEntity();
        }

        private void CreateMappingsForUserEntity() {
            CreateMap<UserDto,User>();
            CreateMap<User,UserDtoWithoutPassword>()
            .ForMember(up => up.BlogId, mappingOption => 
            mappingOption.MapFrom(u => u.Blog.Id));
            CreateMap<User,UserDtoEdit>();
        }
    }

}
