using System.Collections.Generic;
using Blog.Bll.Dto.QueryModels.Base;


namespace Blog.Bll.Dto.QueryModels
{
    public class PostQuery : PagedQuery {
        public string SearchQuery {get; set;}
        public string[] TagNames {get; set;}
    }
}