using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public BlogEntity Blog { get; set; }
        public List<Tag> Tags {get; set;}
        public Boolean IsPublished {get; set;}
    }
}
