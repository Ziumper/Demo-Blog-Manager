using System.Collections.Generic;
using System.Linq;

namespace Blog.Dal.Models.Base
{

public class PagedEntity<T> {
    public int Count {get; set;}
    public List<T> Entities {get; set;}


}

}