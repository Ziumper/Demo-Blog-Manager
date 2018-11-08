using System.Collections.Generic;
using Blog.Bll.Dto.Posts;

namespace Blog.Bll.Dto.Categories{
    public class CategoryDtoWithPosts : CategoryDto {
        public List<PostDto> Posts {get; set;}
    }
}