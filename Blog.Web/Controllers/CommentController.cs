using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Bll.Services.Comments;
using Blog.Bll.Dto;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        // GET: api/Comment
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _commentService.GetCommentById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("addComment")]
        public IActionResult AddComment([FromBody]CommentCreateDto value)
        {
            var result = _commentService.AddCommentToPost(value);
            return Ok(result);
        }

        [HttpGet("commentsByPostId/{postId}")]
        public IActionResult GetAllByPostId(int postId)
        {
            return Ok(_commentService.GetAllCommentsByPostId(postId));
        }
        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CommentDto value)
        {
            var result = _commentService.EditComment(value);
            return Ok(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _commentService.DeleteComment(id);
            return Ok(result);
        }
    }
}
