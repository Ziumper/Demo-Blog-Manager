namespace Bll.Services.ImageWriter {
    
    public class ImplImageWriter : IImageWriter {
        public Task<string> UploadImage(IFormFile file);
    }
}