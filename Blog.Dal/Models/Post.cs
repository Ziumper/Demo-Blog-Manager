using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Models
{
    public class Post : BaseEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BlogId { get; set; }
        public BlogEntity Blog { get; set; }
    }
}
