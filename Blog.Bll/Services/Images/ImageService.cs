using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Images;
using Blog.Bll.Exceptions;
using Blog.Bll.Services.Images.ImageWriter;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Images;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.Images 
{
    public class ImageService : IImageService {


        private readonly IImageWriter _imageWriter;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        
        public ImageService(IImageWriter imageWriter, IImageRepository imageRepository,IMapper mapper) {
            this._imageWriter = imageWriter;
            this._imageRepository = imageRepository;
            this._mapper = mapper;
        }

        public async Task<ImageDto> UploadImage(IFormFile file)
        {
            var extension = _imageWriter.GetImageExtension(file);
            var name = await _imageWriter.UploadImage(file);

            var image = new Image();
            
            image.Name = name;
            image.Extension = extension;

            var resultImage = await _imageRepository.AddAsync(image);

            await _imageRepository.SaveAsync();
         
            var imageDto = _mapper.Map<Image,ImageDto>(resultImage);

            return imageDto;
        }

        public async Task<ImageDto> DeleteImage(int id){
            var image = await _imageRepository.FindByFirstAsync(img => img.Id == id);
            
            if(image == null) {
                throw new ResourceNotFoundException("Image not found");
            }

            try{
                _imageWriter.DeleteImageFileFromServer(image.Name);
            }catch(FileNotFoundException ex) {
                throw ex;
            }finally {
                image = _imageRepository.Delete(image);
                await _imageRepository.SaveAsync();
            }
            
            ImageDto imageDto = _mapper.Map<Image,ImageDto>(image);

            return imageDto; 
        }
    }
}