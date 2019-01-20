
using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.Images
{
    public interface IImageService
    {
        Task<ImageDto> UploadImage(IFormFile file);
        Task<ImageDto> DeleteImage(int id);
    }
}