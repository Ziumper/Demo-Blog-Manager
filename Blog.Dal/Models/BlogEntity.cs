using System.Collections.Generic;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Models
{
    public class BlogEntity : BaseEntity
    {
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
        public int UserId {get; set;}
        public User User {get; set;}
    }
}
