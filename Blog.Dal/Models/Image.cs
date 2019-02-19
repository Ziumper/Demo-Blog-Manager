using Blog.Dal.Models.Base;

namespace Blog.Dal.Models {
    
    public class Image : BaseEntity {
        public string Name {get; set;}
        public string Extension {get; set;}
        public string Url {get; set;}
    }
}