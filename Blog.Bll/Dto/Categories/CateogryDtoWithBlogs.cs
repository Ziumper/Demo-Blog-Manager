using System.Collections.Generic;
using Blog.Bll.Dto.Blogs;

namespace Blog.Bll.Dto.Categories{
    
    public class CategoryDtoWithBlogs : CategoryDto {
        public List<BlogDtoPaged> Blogs {get ;set;}
    }
}