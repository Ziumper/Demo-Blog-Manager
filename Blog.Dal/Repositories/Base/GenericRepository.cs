using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Repositories.Base
{
    public abstract class GenericRepository<T,W>  : IGenericRepository<T> 
        where T: BaseEntity
        where W: DbContext 
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _table;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _table.Where(predicate).ToList();
            }
            else
            {
                return _table.ToList();
            }
        }
        public virtual List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).ToList();
            
        }

        public virtual T Add(T obj)
        { 
            obj.CreationDate = DateTime.Now;
            obj.ModificationDate = DateTime.Now;
            var entity =  _table.Add(obj).Entity;
            
            return entity;
        }

        public T Delete(T obj)
        {
            return _table.Remove(obj).Entity;
        }

        public void DeleteMany(List<T> obj)
        {
            _table.RemoveRange(obj);
        }
        public T Delete(Expression<Func<T, bool>> predicate)
        {
            var entitiy = _table.First(predicate);
            return Delete(entitiy);
        }

        public virtual T Edit(T obj)
        {
            obj.ModificationDate = DateTime.Now;
            return _table.Update(obj).Entity;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public T FindByFirst(Expression<Func<T, bool>> predicate)
        {
           return _table.Where(predicate).First();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return  await _table.Where(predicate).ToListAsync();
            }
            else
            {
                return await _table.ToListAsync();
            }
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate,int take)
        {
            return await _table.Where(predicate).Take(take).ToListAsync();
        }

        public async Task<T> FindByFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.ModificationDate = DateTime.Now;
            var entity = await _table.AddAsync(obj);
            return entity.Entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public int GetSkipCount(int page,int size){
            var skipCount = (page - 1) * size;
            return skipCount;

        }

        public async Task<PagedEntity<T>> GetAllPagedAsync(int page, int size, int filter, bool order) {
            var skipCount = GetSkipCount(page,size);
            var pagedEntity = new PagedEntity<T>();

            var result = _table.AsQueryable();

            result = Sort(result,filter,order);
                
            pagedEntity.Count = await result.CountAsync(); 
            pagedEntity.Entities = await  result.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;

        }

        public async Task<PagedEntity<T>> GetAllPagedAsync(int page, int size, int filter, bool order, Expression<Func<T,bool>> predicate) {
            var skipCount = GetSkipCount(page,size);
            var pagedEntity = new PagedEntity<T>();

            var result = _table.Where(predicate);

            result = Sort(result,filter,order);
             
            pagedEntity.Count = await result.CountAsync(); 
            pagedEntity.Entities = await  result.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;

        }

        public virtual IQueryable<T> Sort(IQueryable<T> entites, int filter, bool order)
        {
            if(order)
            {
                switch (filter)
                {
                    case 0 : {
                         return entites.OrderByDescending(x=> x.Id);
                    }                    
                    case 1 : {   
                        return entites.OrderByDescending(x => x.CreationDate);
                    }
                    case 2: {
                        return entites.OrderByDescending(x => x.ModificationDate);
                    }
                    
                    default: {
                        return entites;
                    }
                }
               
            }else {
                switch (filter)
                {
                    case 0 : {
                         return entites.OrderBy(x=> x.Id);
                    }                    
                    case 1 : {   
                        return entites.OrderBy(x => x.CreationDate);
                    }
                    case 2 : {
                        return entites.OrderBy( x => x.ModificationDate);
                    }
                    
                    default: {
                        return entites;
                    }
                }
            }
        }

        public async Task<PagedEntity<T>> GetAllPagedAsync(int page, int size)
        {
              var skipCount = GetSkipCount(page,size);
            var pagedEntity = new PagedEntity<T>();

            var result = _table.AsQueryable();

            pagedEntity.Count = await result.CountAsync(); 
            pagedEntity.Entities = await  result.Skip(skipCount).Take(size).ToListAsync();

            return pagedEntity;

        }

        public async Task<T> FindByIdFirstAsync(int id)
        {
            var entity = await FindByFirstAsync(t => t.Id == id);
            return entity;
            
        }
    }
}
