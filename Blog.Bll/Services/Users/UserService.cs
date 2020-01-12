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
using Blog.Bll.Services.Authentication;

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
        protected readonly ITokenService _tokenService;

        public UserService(IHashService hashService,
        IUserRepository userRepository,
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IEmailService emailService,
        IHttpContextAccessor htttpContextAccessor,
        IBlogRepository blogRepository,
        ITokenService tokenService
        ) {
            _hashService = hashService;
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _httpContextAccessor = htttpContextAccessor;
            _blogRepository = blogRepository;
            _tokenService = tokenService;
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

            await this._blogRepository.CreateBlogForUser(resultUser);

            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (resultUser);

            return userWithoutPassword;
        }

        public async Task<UserDtoWithoutPassword> Authenticate(string username, string password)
        {  
            var hashedPassword = _hashService.GetHash (password);
            var user = await _userRepository.FindByFirstAsyncWithBlog (x => x.Username == username && x.Password == hashedPassword);

            if (user == null)
                return null;
            if (!user.IsActive) {
                throw new BadRequestException ("User not active, activate your account to login");
            }

            // remove password before returning
            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (user);
            userWithoutPassword.Token = _tokenService.CreateToken(user);

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
            user.Username = user.Username;   
            user.Email = user.Email.ToLower ();
            user.ActivationCode = _hashService.GetRandomActivationCode ();
            
            if(_emailService.ShouldSendingEmail()) {
                user.IsActive = false;
            } else {
                //if not sending email we don't need any activation
                user.IsActive = true;                
            }
            
            user.Role = "Normal";
            var userResult = await _userRepository.AddAsync (user);

            await _userRepository.SaveAsync ();

            if(_emailService.ShouldSendingEmail()) {
                var emailMesssage = _emailService.GetRegisterEmailMessage(userResult);
                _emailService.Send(emailMesssage);
            } 
            
            var userWithoutPassword = _mapper.Map<User, UserDtoWithoutPassword> (userResult);

            return userWithoutPassword;
        }

        
        private async Task<Boolean> IsUserWithThisUserNameIsInDatabase (string username) {
            var user = await _userRepository.FindByFirstAsync (x => x.Username.ToLower() == username.ToLower ());
            if (user != null) {
                return true;
            }

            return false;
        }


        public async Task ResendActivationCode (string userEmail) {

            if(!_emailService.ShouldSendingEmail()) {
                throw new BadRequestException("Sending emails are not avialalbe, to turn on sedning mails please, set sending mails option in configuration");
            }

            var user = await _userRepository.FindByFirstAsync (u => u.Email == userEmail.ToLower ());
            if (user == null) {
                throw new ResourceNotFoundException ("User with that email not found");
            }

            if(user.IsActive) {
                throw new BadRequestException ("User already activated!");
            }

            user.ActivationCode = _hashService.GetRandomActivationCode();

            await _userRepository.SaveAsync();

            
            var emailMessage = _emailService.GetRegisterEmailMessage (user);
            _emailService.Send (emailMessage);
        }

        public async Task<UserDtoEdit> GetUserById(int id)
        {
            var user = await _userRepository.FindByIdFirstAsync(id);

            if(user == null) {
                throw new ResourceNotFoundException("User with that id not found");
            }
            
            UserDtoEdit userDto =_mapper.Map<User,UserDtoEdit>(user);

            return userDto;
        }

        public async Task EditProfile(UserDtoEdit userDtoEdit)
        {
            var user = await _userRepository.FindByIdFirstAsync(userDtoEdit.Id);
            
            if(user == null) {
                throw new ResourceNotFoundException("User with id: " + userDtoEdit.Id + " not found");
            }    

            user.LastName = userDtoEdit.LastName;
            user.FirstName = userDtoEdit.FirstName;
            user.ModificationDate = DateTime.Now;
            
             _userRepository.Edit(user);

             await _userRepository.SaveAsync();
        }

        public async Task ChangePassword(UserDtoChangePassword changePasswordDto)
        {
            var user = await _userRepository.FindByIdFirstAsync(changePasswordDto.Id);
            
            if(user == null) {
                throw new ResourceNotFoundException("User with id: " + changePasswordDto.Id + " not found");
            }

            if(IsPasswordsAreTheSameFromForm(changePasswordDto)) {
                throw new BadRequestException("Passwords are not identical");
            }
            

            user = ChangePasswordForUser(user,changePasswordDto.OldPassword,changePasswordDto.Password);

            _userRepository.Edit(user);

            await _userRepository.SaveAsync();
        }

        private bool IsPasswordsAreTheSameFromForm(UserDtoChangePassword changePasswordDto){
            return changePasswordDto.Password == changePasswordDto.RepeatedPassword;
        }

        private User ChangePasswordForUser(User user,string oldPassword, string newPassword) {
            var oldPasswordHashed = _hashService.GetHash (oldPassword);

            var isUserHaveTheSamePassword = oldPasswordHashed == user.Password;
            if(isUserHaveTheSamePassword) {
                user.Password = _hashService.GetHash(newPassword);
            }

            return user;
        }

        public async Task DeleteUserById(int id)
        {
            var user = await _userRepository.FindByIdFirstAsync(id);
            if(user == null) {
                throw new ResourceNotFoundException("User with id: " + id + " not found");
            }
            _userRepository.Delete(user);
            await  _userRepository.SaveAsync();
        }

        public async Task ChangeUsername(UserDtoChangeUsername userDto)
        {
            var user = await _userRepository.FindByIdFirstAsync(userDto.Id);
            if(user == null) {
                throw new ResourceNotFoundException("User with id " + userDto.Id + " not found");
            }

            if(user.Username == userDto.Username) {
                throw new BadRequestException("Username is exacly the same as previous one, please proivde different one");
            }

           var userWithNewUsername = await _userRepository.FindByFirstAsync(u => u.Username == userDto.Username);
           if(userWithNewUsername != null) {
               throw new BadRequestException("There is already username with this name, please proviee different one");
           }

           user.Username = userDto.Username;

           _userRepository.Edit(user);
           await _userRepository.SaveAsync();
        }
    }
}