using System;
using System.IO;
using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Microsoft.AspNetCore.Http;

namespace Blog.Bll.Services.ImageWriter {
    
    public class ImplImageWriter : IImageWriter {

        private readonly ImageFormatValidator _imageFormatValidator;

        public ImplImageWriter(ImageFormatValidator imageFormatValidator)
        {
            this._imageFormatValidator = imageFormatValidator;
        }


         public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
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

        public async Task<ImageUrlDto> UploadImageForPost(IFormFile file,HostString host)
        {
            string fileName = await this.UploadImage(file);
            var result = new ImageUrlDto();

            result.Url =  host.Host + host.Port + fileName;

            return result;
        }
    }
}