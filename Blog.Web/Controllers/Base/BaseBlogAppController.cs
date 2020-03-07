using System.Threading.Tasks;
using Blog.Bll.Dto.Users;
using Blog.Bll.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers.Base {

    public abstract class BaseBlogAppController : Controller {
        protected IUserService _userService;
        protected IAuthorizationService _authorizationService;

        public BaseBlogAppController(IUserService userService, IAuthorizationService authorizationService) {
            _userService = userService;
            _authorizationService = authorizationService;
        }
        
        protected async Task<AuthorizationResult> GetAuthorizationResult(int id) {
            //get current user to check if availiable
            UserDtoEdit user = await _userService.GetUserById(id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User,user.Username,"EditUserPolicy");
            
            return authorizationResult;
        }

    }
}