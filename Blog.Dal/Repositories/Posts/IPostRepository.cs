using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Posts
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        IEnumerable<Post> FindByWithComments(Expression<Func<Post, bool>> predicate); 
    }
}
