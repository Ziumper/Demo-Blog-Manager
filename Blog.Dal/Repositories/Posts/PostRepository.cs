using Blog.Dal.Models;
using Blog.Dal.Models.Base;
using Blog.Dal.Models.Posts;
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
    public class PostRepository : GenericRepository<Post, BloggingContext>, 
        IPostRepository
    {

        protected IPostWithAuthorSortable _sortablePostWithAutor;
        protected IPostSortable _postSortable;

        public PostRepository(BloggingContext context, 
        IPostWithAuthorSortable sortablePostWithAuthor,
        IPostSortable postSortable) : base(context)
        {
            _sortablePostWithAutor = sortablePostWithAuthor;
            _postSortable = postSortable;
        }

        public async Task<PagedEntity<PostWithAuthor>> GetAllPagedPostsAsyncWithAuthor(int page, int size, int filter, bool order, Expression<Func<Post, bool>> predicate)
        {
            var skipCount = GetSkipCount(page,size);
            var pagedEntity = new PagedEntity<PostWithAuthor>();

            var result = _table.Include(p => p.Blog).Where(predicate).Join
            (
                _context.Users,
                post => post.Blog.UserId,
                user => user.Id,
                (post,user) => new PostWithAuthor(post,user)
            );

            result = _sortablePostWithAutor.Sort(result,filter,order);
             
            pagedEntity.Count = await result.CountAsync();

            var enitites =  await result.Skip(skipCount).Take(size).ToListAsync();
            pagedEntity.Entities = enitites;
            return pagedEntity;
        }

        public async Task<PostWithComments> GetPostWithCommentsAsync(int postId)
        {
            var result = await _table
            .Where(post => post.Id == postId)
            .Include(post => post.Blog)
            .Include(post =>post.Comments)
            .Join(
                _context.Users,
                post => post.Blog.UserId,
                user => user.Id,
                (post,user)=> new PostWithComments(post,user)
            ).FirstOrDefaultAsync();
            
            return result;
        }

        public override IQueryable<Post> Sort(IQueryable<Post> entites, int filter, bool order) {
            return _postSortable.Sort(entites,filter,order);
        }


       
    }
}
