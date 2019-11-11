using Blog.Bll.Dto.Blogs;
using Blog.Bll.Dto.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Blogs
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task<BlogDto> GetBlogByIdAsync(int id);
        Task<BlogDto> AddBlogAsync(BlogDto blog);
        Task<BlogDto> DeleteBlogAsyncById(int id);
        Task<BlogDto> UpdateBlogAsync(BlogDto blog);
        Task<IEnumerable<BlogDto>> GetBlogByTitleAsync(string title);
        Task<BlogDtoPaged> GetAllBlogsPaged(int page, int size);
        Task<BlogDtoPaged> GetAllBlogsPaged(BlogQuery query);
   
    }
}