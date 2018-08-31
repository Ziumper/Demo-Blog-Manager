using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Dto;
using Blog.Bll.Services.Blogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("test")]
        public IActionResult GetTest(){
            return Ok("asdadad");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blogService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("search/{title}")]
        public async Task<IActionResult> GetBlogsByTitle(string title){
            IEnumerable<BlogDto> blogs = null; 
            if(title.Length> 0){
               blogs = await _blogService.GetBlogByTitleAsync(title);
            }
            else blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _blogService.GetBlogByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody]BlogCreateDto blog){
            var result = await _blogService.AddBlogAsync(blog);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody]BlogDto blog){
            var result = await _blogService.UpdateBlogAsync(blog);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id){
            var result = await _blogService.DeleteBlogAsyncById(id);
            return Ok(result);
        }
    }

}