using Blog.Dal.Models;
using Blog.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Tags
{
    public class TagRepository : GenericRepository<Tag, BloggingContext>, ITagRepository
    {
        public TagRepository(BloggingContext context) : base(context)
        {
            
        }
    }
}
