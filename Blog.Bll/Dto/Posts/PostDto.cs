using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Bll.Dto.Posts
{
    public class PostDto: BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
