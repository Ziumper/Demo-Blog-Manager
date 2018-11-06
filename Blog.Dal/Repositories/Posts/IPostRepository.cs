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
        Task<List<Post>> FindByWithCommentsAsync(Expression<Func<Post, bool>> predicate); 
        Task<PagedEntity<Post>> GetPostsPagedByTags(int page,int size,int[] tagsId,Expression<Func<Post,bool>> predicate);
    }
}
