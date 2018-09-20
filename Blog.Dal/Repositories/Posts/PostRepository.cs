using Blog.Dal.Models;
using Blog.Dal.Models.Base;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Posts
{
    public class PostRepository : GenericRepository<Post, BloggingContext>, IPostRepository
    {
        public PostRepository(BloggingContext context) : base(context)
        {

        }

        public IEnumerable<Post> FindByWithComments(Expression<Func<Post, bool>> predicate)
        {
            return _table.Where(predicate).Include(s => s.Comments);
        }

      
        public override IQueryable<Post> Sort(IQueryable<Post> entites, int filter, bool order)
        {
            entites = base.Sort(entites, filter, order);
            if (order)
            {
                switch (filter)
                {
                    case 3:
                        {
                            return entites.OrderByDescending(x => x.Title);
                        }
                    case 4:
                        {
                            return entites.OrderByDescending(x => x.Content);
                        }
                    default:
                        {
                            return entites;
                        }
                }
            }
            else
            {
                switch (filter)
                {
                    case 3:
                        {
                            return entites.OrderBy(x => x.Title);
                        }

                    case 4:
                        {
                            return entites.OrderBy(x => x.Content);
                        }

                    default:
                        {
                            return entites;
                        }
                }
            }

        }

    }
}
