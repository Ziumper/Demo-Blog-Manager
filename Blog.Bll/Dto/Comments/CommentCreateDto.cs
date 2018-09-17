using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bll.Dto.Comments
{
    public class CommentCreateDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
