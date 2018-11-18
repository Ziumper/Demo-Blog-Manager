using System;
using System.Collections.Generic;
using Blog.Bll.Dto.Base;
using Blog.Bll.Dto.Categories;

namespace Blog.Bll.Dto.Blogs
{
    public class BlogDto  : BaseDto
    {
        public string Title { get; set; }
        public CategoryDto Category { get; set;}

    }
}