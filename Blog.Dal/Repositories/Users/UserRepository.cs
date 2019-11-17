using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dal.Repositories.Users {

    public class UserRepository : GenericRepository<User, BloggingContext>, IUserRepository
    {
        public UserRepository(BloggingContext context) : base(context)
        {
            
        }

        public async Task<User> FindByFirstAsyncWithBlog(Expression<Func<User, bool>> predicate)
        {
            return await _table.Include(t => t.Blog).Where(predicate).FirstOrDefaultAsync();
        }
    }
}