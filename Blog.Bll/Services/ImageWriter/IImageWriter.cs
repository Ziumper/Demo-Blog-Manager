using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.ImageWriter {
    
    public interface IImageWriter{
        
        Task<string> UploadImage(IFormFile file);
        Task<ImageUrlDto> UploadImageForPost(IFormFile file,HostString host);
    }
}

