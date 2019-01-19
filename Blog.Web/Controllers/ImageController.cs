using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Services.Image;
using Blog.Bll.Services.Image.ImageWriter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers {
    
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller {

        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile image) {
            var result = await _imageService.uploadImage(image);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteImage(ImageDto image)
        {
            var result = _imageService.DeleteImage(image);
            return Ok(result);
        }

    }
}