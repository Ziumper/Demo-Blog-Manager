using Blog.Dal.Models.Posts;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Posts {

    public interface IPostWithAuthorSortable : ISortable<PostWithAuthor>
    {
        
    }  
}