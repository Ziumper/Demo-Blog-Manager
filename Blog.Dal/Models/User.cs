using Blog.Dal.Models.Base;

namespace Blog.Dal.Models {
    public class User : BaseEntity {
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public bool IsActive {get; set;}
    }
}