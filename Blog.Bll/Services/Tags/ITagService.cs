using System.Threading.Tasks;
using Blog.Bll.Dto.Tags;

namespace Blog.Bll.Services.Tags
{
    public interface ITagService
    {
        Task<TagDto> AddNewTagAsync(string name);
    }
}