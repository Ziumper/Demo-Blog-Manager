using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dal.Repositories.Images {
    public class ImageRepository : GenericRepository<Image, BloggingContext>, IImageRepository
    {
        public ImageRepository(BloggingContext context) : base(context)
        {

        }
    }
}