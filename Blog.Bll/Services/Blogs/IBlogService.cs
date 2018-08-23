using Blog.Bll.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Blogs
{
    public interface IBlogService
    {
       Task<IEnumerable<BlogDto>> GetAllBlogs();
    }
}