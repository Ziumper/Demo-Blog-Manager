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

    
        private async Task<PagedEntity<Post>> GetPaged(IQueryable<Post> query,int page, int size,int filter, bool order) {
            
            var skipCount = GetSkipCount(page,size);
            
            PagedEntity<Post> pagedEntity = new PagedEntity<Post>();

            query = Sort(query,filter,order);

            pagedEntity.Count = await query.CountAsync();

            pagedEntity.Entities = await query.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;
        }

        public async Task<Post> GetPostByIdWithImagesAsync(int postId)
        {
            var post = await _table.Include(p => p.MainImage).Where(p=> p.Id == postId).FirstOrDefaultAsync();
            return post;
        }
    }
}
