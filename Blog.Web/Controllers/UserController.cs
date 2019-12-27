using System.Linq;
using System.Security.Claims;
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

        private IUserService _userService;
        protected IParserService _parserService;

        public UserController (IUserService userService, IParserService parserService) {
            _userService = userService;
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

        [HttpPost("edit-profile")]
        public async Task<IActionResult> EditProfile([FromBody] UserDtoEdit userDtoEdit) {
            await _userService.EditProfile(userDtoEdit);
            return Ok();
        }

        [HttpPost("edit-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserDtoChangePassword userDtoChangePassword) {
            await _userService.ChangePassword(userDtoChangePassword);
            return Ok();
        }

    }
}