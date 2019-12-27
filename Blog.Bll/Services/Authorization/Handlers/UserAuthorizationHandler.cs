using System.Threading.Tasks;
using Blog.Dal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Bll.Services.Authorization {

    public class UserAuthorizationHandler : AuthorizationHandler<SameUserRequierement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequierement requirement, User resource)
        {
            throw new System.NotImplementedException();
        }
    }
}