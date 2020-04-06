using System.Collections.Generic;

namespace Blog.Dal.Models.Posts {

    public class PostWithComments : PostWithAuthor
    {
        public PostWithComments(Post post, User user) : base(post, user)
        {   
            this.Comments = post.Comments;
        }
    }
}