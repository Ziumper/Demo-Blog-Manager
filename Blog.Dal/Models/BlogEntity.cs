using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Models
{
    public class BlogEntity : BaseEntity
    {
        public string Title { get; set; }
        public int BlogEntityId { get; set; }

        public List<Post> Posts { get; set; }
    }
}
