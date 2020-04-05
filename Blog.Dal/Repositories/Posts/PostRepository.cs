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

        public async Task<PagedEntity<PostWithAuthor>> GetAllPagedPostsAsyncWithAuthor(int page, int size, int filter, bool order, Expression<Func<PostWithAuthor, bool>> predicate)
        {
            var skipCount = GetSkipCount(page,size);
            var pagedEntity = new PagedEntity<PostWithAuthor>();

            var result = _table.Join
            (
                _context.Users,
                post => post.BlogId,
                user => user.Blog.Id,
                (post,user) => new PostWithAuthor(post,user)
            ).Where(predicate);

           var sorted = _sortablePostWithAutor.Sort(result,filter,order);
             
            pagedEntity.Count = await result.CountAsync(); 

            var enitites =  await  result.Skip(skipCount).Take(size).ToListAsync();

            pagedEntity.Entities = enitites;
           
            return pagedEntity;
        }

        public override IQueryable<Post> Sort(IQueryable<Post> entites, int filter, bool order) {
            return _postSortable.Sort(entites,filter,order);
        }


       
    }
}
