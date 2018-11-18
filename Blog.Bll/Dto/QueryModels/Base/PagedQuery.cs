namespace Blog.Bll.Dto.QueryModels.Base 
{
    public abstract class PagedQuery {
        public int Page {get;set;}
        public int Size { get; set;}
        public int Filter {get; set;}
        public bool Order {get; set;}
        public string SearchQuery {get;set;}
    }
}