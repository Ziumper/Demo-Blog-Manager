using System.Collections.Generic;

namespace Blog.Bll.Dto
{
    public class BlogDto
    {
        public int BlogEntityId {get;set;}
        public string Title { get; set; }
        public List<PostDto> Posts {get; set;}
    }
}