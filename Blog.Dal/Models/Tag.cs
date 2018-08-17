using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Models
{
    public class Tag : BaseEntity
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
