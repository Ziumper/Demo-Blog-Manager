using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Models {
    public class User : BaseEntity {

        [Key,Column(Order = 0)]
        public new int Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key,Column(Order = 1)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {get; set;}
        public bool IsActive {get; set;}
        public string ActivationCode {get; set;}
        public BlogEntity Blog {get; set;}
    }
}