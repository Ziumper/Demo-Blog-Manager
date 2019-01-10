using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.ImageWriter {
    
    public interface IImageWriter{
        
        Task<string> UploadImage(IFormFile file);

    }
}

