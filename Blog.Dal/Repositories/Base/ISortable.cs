using System.Linq;
using Blog.Dal.Models.Base;

namespace Blog.Dal.Repositories.Base {

    public interface ISortable<T> where T:BaseEntity
    {
        IQueryable<T> Sort(IQueryable<T> entites , int filter,bool order);
    }
}