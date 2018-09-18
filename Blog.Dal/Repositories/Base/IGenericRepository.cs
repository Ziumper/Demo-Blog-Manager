using Blog.Dal.Models;
using Blog.Dal.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Base
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync (Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T,bool>> predicate = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindByFirst(Expression<Func<T,bool>> predicate);
        Task<T> FindByFirstAsync(Expression<Func<T,bool>> predicate);
        T Add(T obj);
        Task<T> AddAsync (T obj);
        T Delete(T obj);
        T Delete(Expression<Func<T, bool>> predicate);
        T Edit(T obj);
        void DeleteMany(IEnumerable<T> obj);
        void Save();
        Task SaveAsync();
        Task<PagedEntity<T>> GetAllPaged(int page,int size,Expression<Func<T,bool>> predicate = null);
        int getSkipCount(int page, int size);

        Task<PagedEntity<T>> GetAllPagedAndFiltered(int page, int size, int filter, bool order, Expression<Func<T, bool>> predicate = null);

        IQueryable<T> Sort(IQueryable<T> entites , int filter,bool order);
    }
}
