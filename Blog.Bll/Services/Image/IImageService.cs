
using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.Image
{
    public interface IImageService
    {
        Task<ImageDto> uploadImage(IFormFile file);
        ImageDto DeleteImage(ImageDto image);
    }
}