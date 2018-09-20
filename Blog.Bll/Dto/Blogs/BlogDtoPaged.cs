using System.Collections.Generic;
using AutoMapper;
using Blog.Bll.Dto.Base;
using Blog.Dal.Models;
using Blog.Dal.Models.Base;

namespace Blog.Bll.Dto.Blogs
{
    public class BlogDtoPaged : BaseDtoPaged<BlogDto, BlogEntity>
    {
        public BlogDtoPaged(IMapper mapper, PagedEntity<BlogEntity> entities, int page, int size) : base(mapper, entities, page, size)
        {
        }
    }

}