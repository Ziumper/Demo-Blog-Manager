using System.Collections.Generic;

namespace Blog.Bll.Dto
{
    public class BlogDtoWithPosts
    {
        public int Id {get;set;}
        public string Title { get; set; }
        public List<PostDto> Posts {get; set;}
    }
}