using System.Linq;
using Blog.Dal.Models.Posts;

namespace Blog.Dal.Repositories.Posts {


    public class PostWithAuthorSortable : BasePostSortable<PostWithAuthor>, IPostWithAuthorSortable
    {
        public override IQueryable<PostWithAuthor> Sort
            (
                IQueryable<PostWithAuthor> entites,
                int filter,
                bool order
            )
        {
            entites = base.Sort(entites,filter,order);
            return entites;
        }
    }
}