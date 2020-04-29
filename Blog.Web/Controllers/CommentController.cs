using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Bll.Services.Comments;
using Blog.Bll.Dto.Comments;
using Blog.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Blog.Bll.Services.Users;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Comment")]
    public class CommentController : BaseBlogAppController
    {
        protected readonly ICommentService _commentService;

        public CommentController(ICommentService commentService,
        IAuthorizationService authorizationService, 
        IUserService userService) : base(userService,authorizationService)
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
        public async Task<IActionResult> AddComment([FromBody]CommentCreateDto value)
        {
            var result = await _commentService.AddCommentToPostAsync(value);
            return Ok(result);
        }

        [HttpGet("comments")]
        public async Task<IActionResult> GetCommentsList([FromQuery] CommentsQueryDto query)
        {
            var result = await _commentService.GetComments(query);
            return Ok(result);
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
