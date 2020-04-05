using Blog.Bll.Dto.Base;
using Blog.Bll.Dto.Images;

namespace Blog.Bll.Dto.Posts
{
    public class PostDto: BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public string ShortDescription { get; set; }
        public string Author {get; set;}
    }
}
