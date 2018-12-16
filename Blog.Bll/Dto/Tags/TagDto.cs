using System;
using System.ComponentModel.DataAnnotations;
using Blog.Bll.Dto.Base;

namespace Blog.Bll.Dto.Tags
{   
    public class TagDto : BaseDto {
        [StringLength(60,MinimumLength=1)]
        [Required]
        public String Name {get; set;}
    }
}