using System.Collections.Generic;

namespace Blog.Bll.Dto
{
    public class BlogCreateDto
    {
        public string Title { get; set; }

        public BlogCreateDto(string Title){
            this.Title = Title;
        }
    }
}