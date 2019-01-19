namespace Blog.Bll.Services.Image.ImageWriter {
    public interface IImageFormatValidator
    {
        ImageFormat GetImageFormat(byte[] bytes);
    }
}