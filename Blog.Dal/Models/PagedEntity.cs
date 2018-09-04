using System.Collections.Generic;

namespace Blog.Dal.Models
{

public class PagedEntity<T> {
    public int Count {get; set;}
    public IEnumerable<T> Entities {get; set;}
}

}