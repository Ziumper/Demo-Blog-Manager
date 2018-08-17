using Blog.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            return _context.Set<T>().Where(predicate);
            
        }
        public virtual T Add(T obj)
        { 
           return _table.Add(obj).Entity;
        }
        public T Delete(T obj)
        {
            return _table.Remove(obj).Entity;
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

    }
}
