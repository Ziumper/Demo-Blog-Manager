using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Services.Images;
using Blog.Bll.Services.Images.ImageWriter;
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

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image) {
            var result = await _imageService.UploadImage(image);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteImage(int id)
        {
            var result = _imageService.DeleteImage(id);
            return Ok(result);
        }

    }
}