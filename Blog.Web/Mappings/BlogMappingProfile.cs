using AutoMapper;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.Comments;
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
        
            CreateMappingsForUserEntity();
        }

        private void CreateMappingsForUserEntity() {
            CreateMap<UserDto,User>();
            CreateMap<User,UserDtoWithoutPassword>()
            .ForMember(up => up.BlogId, mappingOption => 
            mappingOption.MapFrom(u => u.Blog.Id));
        }
    }

}
