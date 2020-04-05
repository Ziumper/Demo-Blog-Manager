using AutoMapper;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.Comments;
using Blog.Bll.Dto.Users;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogEntity,BlogDto>();
            CreateMap<Post,PostDto>()
                .ForMember(p => p.Author, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Post,PostDtoWithComments>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
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
