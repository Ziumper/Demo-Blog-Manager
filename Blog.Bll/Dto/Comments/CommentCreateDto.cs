using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bll.Dto.Base;

namespace Blog.Bll.Dto.Comments
{
    public class CommentCreateDto : BaseDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
