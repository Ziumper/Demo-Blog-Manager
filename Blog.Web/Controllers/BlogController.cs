using System.Threading.Tasks;
using Blog.Bll.Dto.Blogs;
using Blog.Bll.Dto.QueryModels;
using Blog.Bll.Services.Blogs;
using Blog.Bll.Services.Users;
using Blog.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BlogController : BaseBlogAppController
    {
        private readonly IBlogService _blogService;

        public BlogController(
            IBlogService blogService,
            IAuthorizationService authorizationService,
            IUserService userService) : base(userService,authorizationService)
        {
            _blogService = blogService;
        }

        [HttpGet("paged/{p:int}/{size:int}")]
        public async Task<IActionResult> GetAllBlogsPaged(int p,int size){
            var result = await _blogService.GetAllBlogsPaged(p,size);
            return Ok(result);
        }

    
        [HttpGet("paged")]
        public async Task<IActionResult> GetAllBlogsPaged( [FromQuery] BlogQuery searchQuery){
            var result = await _blogService.GetAllBlogsPaged(searchQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blogService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetBlogsByTitle(string title){
            var result = await _blogService.GetBlogByTitleAsync(title);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _blogService.GetBlogByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/posts/{page:int}")]
        public async Task<IActionResult> GetBlogByIdWithPosts(int id,int page) {
            var result = await _blogService.GetBlogByIdAsyncWithPosts(id,page);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody]BlogDto blog){
            var result = await _blogService.AddBlogAsync(blog);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody]BlogDto blog){
            var result = await _blogService.UpdateBlogAsync(blog);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBlog(int id){
            var result = await _blogService.DeleteBlogAsyncById(id);
            return Ok(result);
        }

    }

}