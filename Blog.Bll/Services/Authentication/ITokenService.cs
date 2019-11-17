using System;
using System.Threading.Tasks;
using Blog.Bll.Dto.Users;
using Blog.Dal.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Bll.Services.Authentication {
    
    public interface ITokenService
    {
        String CreateToken(User user);
    }

}