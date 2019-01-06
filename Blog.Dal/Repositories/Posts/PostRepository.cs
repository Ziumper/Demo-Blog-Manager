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

        public async Task<List<Post>> GetAllPostsAsyncByCategoryId(int categoryId,int takeCount)
        {
            var posts =  _table.Where(post => post.Blog.CategoryId == categoryId);
            posts = Sort(posts,1,true).Include(post => post.Blog).Include(post => post.PostTags);
            posts = posts.Take(takeCount);
            return await posts.ToListAsync();
        }

        public async Task<List<Post>> FindByWithCommentsAsyncWithTags(Expression<Func<Post, bool>> predicate)
        {
            return await _table.Where(predicate).Include(s => s.Comments).Include(p => p.PostTags).ThenInclude(postTag => postTag.Tag).ToListAsync();
        }


        public async Task<PagedEntity<Post>> GetPostsPagedByTags(int page, int size,int filter, bool order,int[] tagsId, Expression<Func<Post, bool>> predicate)
        {
            IQueryable<Post> result = null;

            result = _table.Include(post => post.PostTags).ThenInclude(postTag => postTag.TagId)
            .Where(post => post.PostTags.Where( postTag => tagsId.Contains(postTag.TagId)).FirstOrDefault() != null)
            .Where(predicate).Include(post => post.PostTags).ThenInclude(postTag => postTag.Tag);

            var pagedEntity = await GetPaged(result,page,size,filter,order);

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

        public async Task<Post> GetPostByIdWithPostTagsAsync(int postId)
        {
           var post = await _table.Where(x => x.Id == postId).Include(x => x.PostTags).FirstOrDefaultAsync();
           return post;
        }

        public async Task<PagedEntity<Post>> GetPostsPagedWithTagsAsync(int page, int size,int filter, bool order, Expression<Func<Post, bool>> predicate = null)
        {
            if(predicate != null) {
                IQueryable<Post> query = this._table.Where(predicate).Include(post => post.PostTags).ThenInclude(posTag => posTag.Tag);
                var result = await this.GetPaged(query,page,size,filter,order);
                return result;
            } else {
                IQueryable<Post> query = this._table.Include(post => post.PostTags).ThenInclude( postTag => postTag.Tag);
                var result = await this.GetPaged(query,page,size,filter,order);
                return result;
            }
            
        }

        private async Task<PagedEntity<Post>> GetPaged(IQueryable<Post> query,int page, int size,int filter, bool order) {
            
            var skipCount = getSkipCount(page,size);
            
            PagedEntity<Post> pagedEntity = new PagedEntity<Post>();

            query = Sort(query,filter,order);

            pagedEntity.Count = await query.CountAsync();

            pagedEntity.Entities = await query.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;
        }
    }
}
