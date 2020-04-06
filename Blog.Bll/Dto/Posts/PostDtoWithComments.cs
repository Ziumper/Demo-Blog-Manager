using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bll.Dto.Comments;

namespace Blog.Bll.Dto.Posts
{
    public class PostDtoWithComments : PostDtoWithAuthor
    {
        public List<CommentDto> Comments { get; set; }
    }
}
