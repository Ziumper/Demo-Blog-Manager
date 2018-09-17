using System.Collections.Generic;
using Blog.Bll.Dto.Posts;

namespace Blog.Bll.Dto.Blogs
{
    public class BlogDtoWithPosts
    {
        public int Id {get;set;}
        public string Title { get; set; }
        public List<PostDto> Posts {get; set;}
    }
}