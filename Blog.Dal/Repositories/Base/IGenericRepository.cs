using Blog.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Base
{
    public interface IGenericRepository<T> 
    {

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindByFirst(Expression<Func<T,bool>> predicate);
        T Add(T obj);
        T Delete(T obj);
        T Delete(Expression<Func<T, bool>> predicate);
        T Edit(T obj);
        void Save();

    }
}
