
using Blog.Bll.Dto.QueryModels.Base;

namespace Blog.Bll.Dto.QueryModels
{

    public class BlogQuery : PagedQuery
    {
        public string Title { get; set; }
    }
}