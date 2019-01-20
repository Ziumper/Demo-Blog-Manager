namespace Blog.Bll.Services.Images.ImageWriter {
    public interface IImageFormatValidator
    {
        ImageFormat GetImageFormat(byte[] bytes);
    }
}