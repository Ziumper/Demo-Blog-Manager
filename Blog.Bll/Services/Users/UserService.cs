using System.Threading.Tasks;
using Blog.Bll.Dto.Users;

namespace Blog.Bll.Services.Users {

    public class UserService : IUserService
    {
        public Task<UserDtoWithoutPassword> ActivateUser(UserDtoActivation activationUserDetails)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDtoWithoutPassword> Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDtoWithoutPassword> Register(UserDto userParam)
        {
            throw new System.NotImplementedException();
        }

        public Task ResendActivationCode(string useremail)
        {
            throw new System.NotImplementedException();
        }
    }
}