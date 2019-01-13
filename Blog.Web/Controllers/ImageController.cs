using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Services.ImageWriter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers {
    
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller {

        private readonly IImageWriter _imageWriter;

        public ImageController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile image,int postId) {
            
            return Ok("test");
        }

    }
}