using AutoMapper;
using Blog.Bll.Dto.Base;
using Blog.Dal.Models.Base;
using Blog.Dal.Models.Posts;

namespace Blog.Bll.Dto.Posts {


    public class PostDtoPagedWithAuthor : BaseDtoPaged<PostDtoWithAuthor, PostWithAuthor> {
        public PostDtoPagedWithAuthor(IMapper mapper, PagedEntity<PostWithAuthor> entities, int page, int size)
         : base(mapper, entities, page, size)
        {
        }
    }
}