using System.Threading.Tasks;
using Blog.Bll.Dto.Users;

namespace Blog.Bll.Services.Users {

    public interface IUserService
    {
        Task<UserDtoWithoutPassword> Register(UserDto userParam);
        Task<UserDtoWithoutPassword> Authenticate(string username, string password);
        Task<UserDtoWithoutPassword> ActivateUser(UserDtoActivation activationUserDetails);
        Task ResendActivationCode(string useremail);
        Task<UserDtoEdit> GetUserById(int id);
        Task EditProfile(UserDtoEdit userDtoEdit);
        Task ChangePassword(UserDtoChangePassword changePasswordDto);
    }
}