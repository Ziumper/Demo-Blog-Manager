using System.Collections.Generic;

namespace Blog.Bll.Dto
{
    public class BlogDtoPaged
    {
        public int Page {get;set;}
        public List<BlogDto> Blogs { get; set; }
        public int Size {get; set;}
        public int Count {get; set;}
    }
}