using Blog.Bll.Dto.Base;

namespace Blog.Bll.Dto.Images {
    public class ImageDto : BaseDto {
        public string Name {get; set;}
        public string Extension {get; set;}
        public string Url {get; set;}
    }
}