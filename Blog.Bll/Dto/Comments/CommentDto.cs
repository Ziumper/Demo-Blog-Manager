using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Dto.Base;

namespace Blog.Bll.Dto.Comments
{
    public class CommentDto : BaseDto
    {
        public string Content { get; set; }

    }
}
