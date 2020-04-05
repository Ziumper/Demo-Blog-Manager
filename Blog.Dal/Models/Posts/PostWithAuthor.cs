namespace Blog.Dal.Models.Posts {

    public class PostWithAuthor : Post {
        private Post post;
        private User user;

        public PostWithAuthor(Post post, User user)
        {
            this.post = post;
            this.user = user;

            this.Author = this.user.Username;
        }

        public string Author {get; set;}
    }

}