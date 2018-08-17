using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Models
{
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public int PostId { get; set; }
        public List<Post> Posts { get; set; }
    }
}
