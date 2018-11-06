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

        public async Task<List<Post>> FindByWithCommentsAsync(Expression<Func<Post, bool>> predicate)
        {
            return await _table.Where(predicate).Include(s => s.Comments).ToListAsync();
        }


        public async Task<PagedEntity<Post>> GetPostsPagedByTags(int page, int size,int[] tagsId, Expression<Func<Post, bool>> predicate)
        {
            var skipCount = getSkipCount(page,size);
            
            PagedEntity<Post> pagedEntity = new PagedEntity<Post>();
            IQueryable<Post> result = null;

            result = _table.Include(post => post.PostTags).ThenInclude(postTag => postTag.TagId)
            .Where(post => post.PostTags.Where( postTag => tagsId.Contains(postTag.TagId)).FirstOrDefault() != null)
            .Where(predicate);

            pagedEntity.Count = await result.CountAsync();

            pagedEntity.Entities = await result.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;
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
