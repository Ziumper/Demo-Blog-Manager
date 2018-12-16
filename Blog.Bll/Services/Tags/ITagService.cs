using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Bll.Dto.Tags;

namespace Blog.Bll.Services.Tags
{
    public interface ITagService
    {
        Task<TagDto> AddNewTagAsync(TagDto tagDto);
        Task<TagDto> DeleteTagAsync(int id);
        Task<TagDto> EditTagAsync(TagDto tagDto);
        Task<List<TagDto>> GetAllTagsAsync();
        
    }
}