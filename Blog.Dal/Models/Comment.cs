using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Dal.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
