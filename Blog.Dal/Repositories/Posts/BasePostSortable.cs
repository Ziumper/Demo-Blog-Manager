using System.Linq;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;

namespace Blog.Dal.Repositories.Posts {

    public abstract class BasePostSortable<T> : Sortable<T> where T: Post {
        public override IQueryable<T> Sort(IQueryable<T> entites, int filter, bool order)
        {
              entites = base.Sort(entites, filter, order);
            if (order)
            {
                switch (filter)
                {
                    case 3:
                        {
                            return entites.OrderByDescending(x => x.Title);
                        }
                    case 4:
                        {
                            return entites.OrderByDescending(x => x.Content);
                        }
                    default:
                        {
                            return entites;
                        }
                }
            }
            else
            {
                switch (filter)
                {
                    case 3:
                        {
                            return entites.OrderBy(x => x.Title);
                        }

                    case 4:
                        {
                            return entites.OrderBy(x => x.Content);
                        }

                    default:
                        {
                            return entites;
                        }
                }
            }
        }
    }
}