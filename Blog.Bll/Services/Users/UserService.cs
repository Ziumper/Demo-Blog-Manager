using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Blog.Bll.Dto.Users;
using Blog.Bll.Exceptions;
using Blog.Bll.Services.Utility;
using Blog.Dal.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Blog.Bll.Dto.App;
using System;
using Blog.Dal.Models;
using Blog.Bll.Services.Emails;
using Microsoft.AspNetCore.Http;
using Blog.Bll.Services.Emails.Models;
using System.Collections.Generic;
using Blog.Dal.Repositories.Blogs;

namespace Blog.Bll.Services.Users {

    public class UserService : IUserService
    {
        protected readonly IHashService _hashService; 
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
        protected readonly AppSettings _appSettings;
        protected readonly IEmailService _emailService;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IBlogRepository _blogRepository;

        public UserService(IHashService hashService,
        IUserRepository userRepository,
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IEmailService emailService,
        IHttpContextAccessor htttpContextAccessor,
        IBlogRepository blogRepository) {
            _hashService = hashService;
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _httpContextAccessor = htttpContextAccessor;
            _blogRepository = blogRepository;
            
        }

        public async Task<UserDtoWithoutPassword> ActivateUser(UserDtoActivation activationUserDetails)
        {
             var user = await _userRepository.FindByFirstAsync (u => u.Id == activationUserDetails.Id);
            if (user == null) {
                throw new ResourceNotFoundException ("Activation user not found!");
            }

            if (user.ActivationCode != activationUserDetails.Code) {
                throw new BadRequestException ("Wrong activation code!");
            }

            if(user.IsActive) {
                throw new BadRequestException("User already activated");
            }

            user.IsActive = true;

            var resultUser = _userRepository.Edit (user);
            await _userRepository.SaveAsync ();

            await this.CreateBlogForUser(resultUser);

            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (resultUser);

            return userWithoutPassword;
        }

        //TODO move this method to blog repository
        private async Task CreateBlogForUser(User user) {
            BlogEntity blogEntity = new BlogEntity();
            blogEntity.User = user;
            await _blogRepository.AddAsync(blogEntity);
            await _blogRepository.SaveAsync();
        }

        public async Task<UserDtoWithoutPassword> Authenticate(string username, string password)
        {  var hashedPassword = _hashService.GetHash (password);
            var user = await _userRepository.FindByFirstAsync (x => x.Username == username && x.Password == hashedPassword);

            // return null if user not found
            if (user == null)
                return null;

            if (!user.IsActive) {
                throw new BadRequestException ("User not active, activate your account to login");
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.Name, user.Id.ToString ())
                }),
                Expires = DateTime.UtcNow.AddDays (7),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken (tokenDescriptor);

            // remove password before returning
            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (user);
            userWithoutPassword.Token = tokenHandler.WriteToken (token);

            return userWithoutPassword;
        }

         public async Task<UserDtoWithoutPassword> Register (UserDto userParam) {
            if (await IsUserWithThisUserNameIsInDatabase (userParam.Username)) {
                throw new BadRequestException ("There is a user with this username!");
            }
            if (await IsUserWithThisUserNameIsInDatabase (userParam.Email)) {
                throw new BadRequestException ("There is a user with this email!");
            }

            userParam.Password = _hashService.GetHash (userParam.Password);
            var user = _mapper.Map<UserDto, User> (userParam);
            user.Username = user.Username.ToLower();   
            user.Email = user.Email.ToLower ();
            user.IsActive = true;
            user.ActivationCode = _hashService.GetRandomActivationCode ();
           
            var userResult = await _userRepository.AddAsync (user);

            

            await _userRepository.SaveAsync ();

            // TODO catch exception if email send error.
            //var emailMesssage = GetRegisterEmailMessage(userResult);
            //_emailService.Send(emailMesssage);
          
            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (userResult);

            return userWithoutPassword;
        }

        private EmailMessage GetRegisterEmailMessage (User user) {
            EmailMessage emailMesssage = new EmailMessage ();
            emailMesssage.FromAddresses = new List<EmailAddress> ();
            emailMesssage.ToAddresses = new List<EmailAddress> ();

            EmailAddress emailAddres = new EmailAddress ();
            emailAddres.Address = "demom@email.com";
            emailAddres.Name = "demo bot";
            emailMesssage.FromAddresses.Add (emailAddres);

            EmailAddress userEmailAddres = new EmailAddress ();
            userEmailAddres.Name = user.FirstName + " " + user.LastName;
            userEmailAddres.Address = user.Email;
            emailMesssage.ToAddresses.Add (userEmailAddres);

            emailMesssage.Subject = "Activation code";

            var host = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";

            emailMesssage.Content = "Please go to " + host + "/activation/" + user.Id + " and a activate your account<br/> Here is your activation code: <b>" + user.ActivationCode + "</b>";

            return emailMesssage;
        }

        private async Task<Boolean> IsUserWithThisUserNameIsInDatabase (string username) {
            var user = await _userRepository.FindByFirstAsync (x => x.Username == username.ToLower ());
            if (user != null) {
                return true;
            }

            return false;
        }


        public async Task ResendActivationCode (string userEmail) {
            var user = await _userRepository.FindByFirstAsync (u => u.Email == userEmail.ToLower ());
            if (user == null) {
                throw new ResourceNotFoundException ("User with that email not found");
            }
            var emailMessage = GetRegisterEmailMessage (user);
            _emailService.Send (emailMessage);
        }

    }
}