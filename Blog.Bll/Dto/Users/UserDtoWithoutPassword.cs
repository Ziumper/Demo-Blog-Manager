using Blog.Bll.Dto.Base;

namespace Blog.Bll.Dto.Users {

   public class UserDtoWithoutPassword : BaseDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }   

        public int BlogId {get; set;}    
    }
}