using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dal.Repositories.Users {

    public class UserRepository : GenericRepository<User, BloggingContext>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        
    }
}