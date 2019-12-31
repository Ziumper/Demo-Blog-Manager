using System.Threading.Tasks;
using Blog.Dal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Bll.Services.Authorization {

    public class UserAuthorizationHandler : AuthorizationHandler<SameUserRequirement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, User resource)
        {
            if(context.User.Identity?.Name == resource.Username) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}