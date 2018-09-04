﻿using Blog.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
           var entity = await _table.AddAsync(obj);
           return entity.Entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
