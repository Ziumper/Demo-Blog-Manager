using System;
using System.Collections.Generic;
using System.Text;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Models
{
    public class BlogEntity : BaseEntity
    {
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}
