﻿using System.Threading.Tasks;
using Blog.Bll.Dto;
using Blog.Bll.Services.Blogs;
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
            return Ok("Test controller");
        }

        [HttpGet("paged/{p:int}/{size:int}")]
        public async Task<IActionResult> GetAllBlogsPaged(int p,int size){
            var result = await _blogService.GetAllBlogsPaged(p,size);
            return Ok(result);
        }

        
        [HttpGet("paged/{p:int}/{size:int}/{filter:int}/{order:bool}")]
        public async Task<IActionResult> GetAllBlogsPagedAndFiltered(int p,int size,int filter, bool order){
            var result = await _blogService.GetAllBlogsPagedAndFiltered(p,size,filter,order);
            return Ok(result);
        }

         [HttpGet("paged/{p:int}/{size:int}/{filter:int}/{order:bool}/{title}")]
        public async Task<IActionResult> GetAllBlogsPagedAndFilteredByTitle(int p,int size,int filter, bool order,string title){
            var result = await _blogService.GetAllBlogsPagedAndFilteredByTitle(p,size,filter,order,title);
            return Ok(result);
        }


        [HttpGet("paged/{p:int}/{size:int}/{title}")]
        public async Task<IActionResult> GetBlogsPagedByTitle(int p,int size,string title){
            var result = await _blogService.GetAllBlogsPagedByTitle(title,p,size);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBlog(int id){
            var result = await _blogService.DeleteBlogAsyncById(id);
            return Ok(result);
        }

    }

}