namespace Blog.Bll.Dto.Users {

    public class UserDtoChangePassword {
        public int Id {get; set;}
        public string Password {get;set;}
        public string RepeatedPassword { get; set;}
        public string OldPassword { get; set;}
    }
}