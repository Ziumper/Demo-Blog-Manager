using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Dto.Users;
using Blog.Bll.Services.Users;
using Blog.Bll.Services.Utility;
using Blog.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers {

    [Authorize]
    [ApiController]
    [Route ("api/[controller]")]
    public class UserController : BaseBlogAppController {
        protected IParserService _parserService;

        public UserController (
        IUserService userService, 
        IParserService parserService,
        IAuthorizationService authorizationService) : base(userService,authorizationService) {
            _parserService = parserService;
        }

        [AllowAnonymous]
        [HttpPost ("authenticate")]
        public async Task<IActionResult> Authenticate ([FromBody] UserDto userParam) {
            UserDtoWithoutPassword user = await _userService.Authenticate (userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest (new { message = "Username or password is incorrect" });

            return Ok (user);
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] UserDto userParam) {
            UserDtoWithoutPassword user = await _userService.Register (userParam);
            return Ok (user);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id) {
            var user = await _userService.GetUserById(id);
            return Ok (user);
        }

        [AllowAnonymous]
        [HttpPut ("activation")]
        public async Task<IActionResult> Activate ([FromBody] UserDtoActivation activationUserDetails) {
            await _userService.ActivateUser (activationUserDetails);
            return Ok ();
        }

        [HttpPut("update")]
        public async Task<IActionResult> EditProfile([FromBody] UserDtoEdit userDtoEdit)
        {
            var authorizationResult = await GetAuthorizationResult(userDtoEdit.Id);

            if (authorizationResult.Succeeded)
            {
                await _userService.EditProfile(userDtoEdit);
                return Ok();
            }
            return Forbid();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserDtoChangePassword userDtoChangePassword) {
            var authorizationResult = await GetAuthorizationResult(userDtoChangePassword.Id);
            if(authorizationResult.Succeeded) {
                await _userService.ChangePassword(userDtoChangePassword);
                return Ok();
            }

            return Forbid();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserById(int id) {
            var authorizationResult = await GetAuthorizationResult(id);
            if(authorizationResult.Succeeded) {
                await _userService.DeleteUserById(id);
                return Ok();
            }

            return Forbid();
        }
    }
}