using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bll.Dto.Comments;

namespace Blog.Bll.Dto.Posts
{
    public class PostDtoWithComments : PostDto
    {
        public List<CommentDto> Comments { get; set; }
    }
}
