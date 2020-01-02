namespace Blog.Bll.Dto.Users {

    public class UserDtoEdit {
        public int Id {get; set;}
        public string FirstName {get;set;}
        public string LastName {get; set;}
        public string Username {get; set;}

        //To check if current password is ok.
        public string Password { get ;set; }
    }
}