using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Services.Image.ImageWriter;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.Image 
{
    public class ImageService : IImageService {


        private readonly IImageWriter _imageWriter;
        
        public ImageService(IImageWriter imageWriter) {
            this._imageWriter = imageWriter;
        }

        public async Task<ImageDto> uploadImage(IFormFile file)
        {
            var name = await _imageWriter.UploadImage(file);
            var extension = _imageWriter.GetImageExtension(file);

            var imageDto = new ImageDto();

            imageDto.Name = name;
            imageDto.Extension = extension;

            return imageDto;
        }

        public ImageDto DeleteImage(ImageDto image){
            var isDeleted =_imageWriter.DeleteImageFromServer(image.Name);
            return image;
        }
    }
}