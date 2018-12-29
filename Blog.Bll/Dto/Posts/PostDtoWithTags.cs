using System.Collections.Generic;
using Blog.Bll.Dto.Tags;

namespace Blog.Bll.Dto.Posts{
    public class PostDtoWithTags : PostDto {
        public List<TagDto> PostTags {get; set;}
    }
}