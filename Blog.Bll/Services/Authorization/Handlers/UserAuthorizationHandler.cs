using System.Threading.Tasks;
using Blog.Dal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Bll.Services.Authorization {

    public class UserAuthorizationHandler : AuthorizationHandler<AuthorUserRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorUserRequirement requirement, string resource)
        {
            if(context.User.Identity?.Name == resource) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}