using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Bll.Dto.Tags;

namespace Blog.Bll.Services.Tags
{
    public interface ITagService
    {
        Task<TagDto> AddNewTagAsync(string name);
        Task<TagDto> DeleteTagAsync(int id);
        Task<TagDto> EditTagAsync(int id, string name);
        Task<List<TagDto>> GetAllTagsAsync();
        
    }
}