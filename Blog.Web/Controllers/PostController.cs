using System;
using System.Collections.Generic;
using Blog.Bll.Dto;
using Blog.Bll.Exceptions;
using Blog.Bll.Services.Comments;
using Blog.Bll.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/Post
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postService.GetAllPosts());
        }

         [HttpGet("postsByBlogId/{id}")]
        public IActionResult GetALlPostsByBlogId(){
            return Ok();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _postService.GetPostById(id);
            return Ok(result);
        }

        [HttpGet("postWithCommentsById/{id}")]
        public IActionResult GetPostWithCommentsById(int id)
        {
            PostDto result = null;
            result = _postService.GetPostWithCommentsById(id);
            return Ok(result);
        }


        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody]PostCreateDto value)
        {
            var result = _postService.AddPost(value);
            return Ok(result);
        }

    
        
        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] PostDto value)
        {
            var result = _postService.EditPost(value);
            return Ok(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _postService.DeletePost(id);
            return Ok(result);
        }
    }
}
