using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Posts {

    public interface IPostSortable : ISortable<Post>
    {
        
    }
}