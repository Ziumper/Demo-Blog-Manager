using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bll.Dto
{
    public class PostDtoWithComments : PostDto
    {
        public List<CommentDto> Comments { get; set; }
    }
}
