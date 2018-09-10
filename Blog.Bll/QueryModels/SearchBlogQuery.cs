
namespace Blog.Bll.QueryModels{

    public class SearchBlogQuery {
        public int Page {get;set;}
        public int Size { get; set;}
        public int Filter {get; set;}
        public bool Order {get; set;}
        public string Title { get; set;}
    }
}