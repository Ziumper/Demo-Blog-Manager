namespace Blog.Dal.Models.Posts {

    public class PostWithAuthor : Post {
        private Post post;
        private User user;

        public PostWithAuthor(Post post, User user)
        {
            this.post = post;
            this.user = user;

            this.Author = this.user.Username;
            this.Blog = this.post.Blog;
            this.BlogId = this.post.BlogId;
            this.Comments = this.post.Comments;
            this.Content = this.post.Content;
            this.CreationDate = this.post.CreationDate;
            this.ModificationDate = this.post.ModificationDate;
            this.Id = this.post.Id;
            this.Title = this.post.Title;
            this.ShortDescription = this.post.ShortDescription;
            this.AuthorId = user.Id;
        }

        public string Author {get; set;}
        public int AuthorId {get; set;}
    }

}