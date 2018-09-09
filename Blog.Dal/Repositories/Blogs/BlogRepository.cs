using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Repositories.Blogs
{
    public class BlogRepository : GenericRepository<BlogEntity, BloggingContext>, IBlogRepository
    {
        public BlogRepository(BloggingContext context) : base(context)
        {
        }

        public async Task<PagedEntity<BlogEntity>> GetAllBlogsPagedAndFilteredByOrder(int page, int size, int filter, bool order, Expression<Func<BlogEntity, bool>> predicate = null)
        {
            var skipCount = getSkipCount(page,size);

            PagedEntity<BlogEntity> pagedEntity = new PagedEntity<BlogEntity>();

            if(predicate != null){
            
                var result = _table.Where(predicate);
                result = SortBlogs(result,filter,order);

                pagedEntity.Count = result.Count();

                var modelList = await result.Skip(skipCount).Take(size).ToListAsync();
                
                pagedEntity.Entities = modelList;
                return pagedEntity;
            }
            
            pagedEntity.Count = await _table.CountAsync();
            IQueryable<BlogEntity> query = _table;
            query = SortBlogs(query,filter,order);
            pagedEntity.Entities = await query.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;
        }

        public async Task<BlogEntity> GetBlogByIdWithPosts(int id)
        {
            var blog = await _table.Where(b => b.Id == id).Include(b => b.Posts).FirstAsync();
            return blog;
        }

        private IQueryable<BlogEntity> SortBlogs(IQueryable<BlogEntity> blogs,int filter,bool order){
            if(order)
            {
                switch (filter)
                {
                    case 0 : {
                         return blogs.OrderByDescending(x=> x.Id);
                    }                    
                    case 1 : {   
                        return blogs.OrderByDescending(x => x.TechDate);
                    }
                    case 2 :{
                        return blogs.OrderByDescending(x=> x.Title);
                    }
                    
                    default: {
                        return blogs;
                    }
                }
               
            }else {
                switch (filter)
                {
                  case 0 : {
                         return blogs.OrderBy(x=> x.Id);
                    }                    
                    case 1 : {   
                        return blogs.OrderBy(x => x.TechDate);
                    }
                    case 2 :{
                        return blogs.OrderBy(x=> x.Title);
                    }
                    
                    default: {
                        return blogs;
                    }
                }
            }

        }
    }
}
