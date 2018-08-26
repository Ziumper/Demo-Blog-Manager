using Blog.Bll.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Blogs
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task<BlogDto> GetBlogByIdAsync(int id);
        Task<BlogDto> AddBlogAsync(BlogCreateDto blog);

        Task<BlogDto> DeleteBlogAsyncById(int id);
    }
}