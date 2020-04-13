namespace Blog.Bll.Dto.Posts {

    public class PostDtoWithAuthor : PostDto {
        public string BlogTitle { get; set;}
        public string Author {get; set;}
    }
}