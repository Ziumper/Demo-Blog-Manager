using System;
using System.IO;
using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Exceptions;
using Microsoft.AspNetCore.Http;
using FileNotFoundException = Blog.Bll.Exceptions.FileNotFoundException;

namespace Blog.Bll.Services.Images.ImageWriter {
    
    public class ImplImageWriter : IImageWriter {

        private readonly IImageFormatValidator _imageFormatValidator;

        public ImplImageWriter(IImageFormatValidator imageFormatValidator)
        {
            this._imageFormatValidator = imageFormatValidator;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            throw new InvalidImageFormatException("Wrong file format");
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }   


            return _imageFormatValidator.GetImageFormat(fileBytes) != ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
           
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                            //for the file due to security reasons.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

            using (var bits = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(bits);
            }

            return fileName;
        }

        public string GetImageExtension(IFormFile file){
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }   

            ImageFormat imageFormat = _imageFormatValidator.GetImageFormat(fileBytes);
            
            if(imageFormat == ImageFormat.unknown) {
                throw new InvalidImageFormatException("Unkown image format");
            }

            string extension = imageFormat.ToString();

            return extension;
        }

        public bool DeleteImageFileFromServer(string imageName) {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", imageName);

           if(System.IO.File.Exists(path))
           {
               System.IO.File.Delete(path);
               return true;
           }else throw new FileNotFoundException("Image file not found");
        }

    }
}