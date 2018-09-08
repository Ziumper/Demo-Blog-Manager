using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

    }
}
