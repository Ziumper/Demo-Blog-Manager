using System.Collections.Generic;
using AutoMapper;
using Blog.Bll.Dto.Base;
using Blog.Dal.Models;
using Blog.Dal.Models.Base;

namespace Blog.Bll.Dto.Posts{

    public class PostDtoPaged : BaseDtoPaged<PostDto, Post>
    {
        public PostDtoPaged(IMapper mapper, PagedEntity<Post> entities, int page, int size) : base(mapper, entities, page, size)
        {
        }
    }
}