using System.Threading.Tasks;
using Blog.Bll.Dto.Images;
using Blog.Bll.Services.Images;
using Blog.Bll.Services.Images.ImageWriter;
using Blog.Bll.Services.Users;
using Blog.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers {
    
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : BaseBlogAppController {

        private readonly IImageService _imageService;

        public ImageController(IImageService imageService,
        IUserService userService, 
        IAuthorizationService authorizationService) : base (userService,authorizationService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file) {
            var result = await _imageService.UploadImage(file);
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