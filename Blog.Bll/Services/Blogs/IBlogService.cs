using Blog.Bll.Dto;
using System.Collections.Generic;

namespace Blog.Bll.Services.Blogs
{
    public interface IBlogService
    {
        List<BlogDto> GetAllBlogs();
    }
}