using Blog.Bll.Dto.QueryModels;
using Blog.Bll.Dto.QueryModels.Base;

namespace Blog.Bll.QueryModels{

    public class BlogCategoryQuery: BlogQuery{
        public int CategoryId {get;set;}

    }
}