using Blog.Dal.Models;
using Blog.Dal.Models.Base;
using Blog.Dal.Models.Posts;
using Blog.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Posts
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        Task<PagedEntity<PostWithAuthor>> GetAllPagedPostsAsyncWithAuthor(
            int page,
            int size,
            int filter, 
            bool order,
            Expression<Func<Post,bool>> predicate
        );

        Task<PostWithAuthor> GetPostWithAuhtor(int postId);
    }
}
