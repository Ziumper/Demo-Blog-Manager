using Blog.Dal.Models;
using Blog.Dal.Models.Base;
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
        Task<List<Post>> FindByWithCommentsAsyncWithTags(Expression<Func<Post, bool>> predicate); 
        Task<PagedEntity<Post>> GetPostsPagedByTags(int page,int size,int filter, bool order,int[] tagsId,Expression<Func<Post,bool>> predicate);
        Task<List<Post>> GetAllPostsAsyncByCategoryId(int categoryId,int takeCount);
        Task<PagedEntity<Post>> GetPostsPagedWithTagsAsync(int page,int size,int filter, bool order, Expression<Func<Post,bool>> predicate);
        Task<Post> GetPostByIdWithPostTagsAsync(int postId);

        Task<Post> GetPostByIdWithImagesAsync(int postId);
    }
}
