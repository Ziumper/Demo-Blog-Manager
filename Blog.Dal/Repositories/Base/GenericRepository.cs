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
    public abstract class GenericRepository<T,W>  : IGenericRepository<T> where T: BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _table;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _table.Where(predicate);
            }
            else
            {
                return _table.AsEnumerable();
            }
        }
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate);
            
        }

        public virtual T Add(T obj)
        { 
            obj.CreationDate = new DateTime();
            obj.ModificationDate = new DateTime();
            var entity =  _table.Add(obj).Entity;
            
            return entity;
        }

        public T Delete(T obj)
        {
            return _table.Remove(obj).Entity;
        }

        public void DeleteMany(IEnumerable<T> obj)
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
            obj.ModificationDate = new DateTime();
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

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
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

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<T> FindByFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            obj.CreationDate = new DateTime();
            obj.ModificationDate = new DateTime();
            var entity = await _table.AddAsync(obj);
            return entity.Entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public int getSkipCount(int page,int size){
            var skipCount = (page - 1) * size;
            return skipCount;

        }

        public async Task<PagedEntity<T>> GetAllPagedAsync(int page,int size){
            var skipCount = getSkipCount(page,size);
            PagedEntity<T> pagedEntity = new PagedEntity<T>();
            pagedEntity.Count = await _table.CountAsync();

            pagedEntity.Entities = await _table.Skip(skipCount).Take(size).ToListAsync();
            return pagedEntity;
        }

        public async Task<PagedEntity<T>> GetAllPagedAsync(int page, int size, Expression<Func<T,bool>> predicate){
            var skipCount = getSkipCount(page,size);
            PagedEntity<T> pagedEntity = new PagedEntity<T>();
            var result = _table.Where(predicate);
            
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
    }
}
