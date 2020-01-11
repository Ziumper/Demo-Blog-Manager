using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Bll.Dto.App;
using Blog.Dal.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Bll.Services.Authentication {


    public class TokenService : ITokenService
    {
        protected readonly AppSettings _appSettings;
        public TokenService(
            IOptions<AppSettings> appSettings
        ) {
            _appSettings = appSettings.Value;
        }

        public String CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler ();
            byte[] key = Encoding.ASCII.GetBytes (_appSettings.Secret);
            var tokenDescriptor = CreateTokenDescriptior(user,key);
            SecurityToken securedToken = tokenHandler.CreateToken (tokenDescriptor);
            string token = tokenHandler.WriteToken(securedToken);

            return token;
        }

        private SecurityTokenDescriptor CreateTokenDescriptior(User user,byte[] key) {
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.Name, user.Username),
                new Claim (ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays (7),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }
    }
}