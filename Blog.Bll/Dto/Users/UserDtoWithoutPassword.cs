namespace Blog.Bll.Dto.Users {

   public class UserDtoWithoutPassword {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }   

        public int BlogId {get; set;}    
    }
}