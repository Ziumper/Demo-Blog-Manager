using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Dal.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id {get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}