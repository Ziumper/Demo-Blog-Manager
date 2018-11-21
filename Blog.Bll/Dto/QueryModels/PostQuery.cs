using System.Collections.Generic;
using Blog.Bll.Dto.QueryModels.Base;


namespace Blog.Bll.Dto.QueryModels
{
    public class PostQuery : PagedQuery {
        public int[] TagsId {get; set;}
        public int BlogId {get; set;}
    }
}