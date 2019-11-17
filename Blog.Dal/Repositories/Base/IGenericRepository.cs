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
        Task<List<T>> GetAllAsync (Expression<Func<T, bool>> predicate = null);
        Task<List<T>> FindByAsync(Expression<Func<T,bool>> predicate = null);
        Task<List<T>> FindByAsync(Expression<Func<T,bool>> predicate, int take);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindByFirst(Expression<Func<T,bool>> predicate);
        Task<T> FindByFirstAsync(Expression<Func<T,bool>> predicate);
        T Add(T obj);
        Task<T> AddAsync (T obj);
        T Delete(T obj);
        T Delete(Expression<Func<T, bool>> predicate);
        T Edit(T obj);
        void DeleteMany(List<T> obj);
        void Save();
        Task SaveAsync();
        int GetSkipCount(int page, int size);
        Task<PagedEntity<T>> GetAllPagedAsync(int page, int size);
        Task<PagedEntity<T>> GetAllPagedAsync(int page,int size,int filter, bool order);
        Task<PagedEntity<T>> GetAllPagedAsync(int page,int size,int filter, bool order,Expression<Func<T,bool>> predicate);
        IQueryable<T> Sort(IQueryable<T> entites , int filter,bool order);
        Task<T> FindByIdFirstAsync(int id);            
    }
}
