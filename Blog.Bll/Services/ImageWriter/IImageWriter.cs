namespace Blog.Bll.Services.ImageWriter {
    
    public interface IImageWriter{
        
        Task<string> UploadImage(IFormFile file);

    }
}

