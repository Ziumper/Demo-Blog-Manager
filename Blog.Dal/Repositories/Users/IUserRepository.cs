using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories {
    
    public interface IUserRepository : IGenericRepository<User> {
        //TODO find a way to make it in generic way, by generic i understand to take property of unkown class and use include
        Task<User> FindByFirstAsyncWithBlog(Expression<Func<User, bool>> predicate);
    }
}