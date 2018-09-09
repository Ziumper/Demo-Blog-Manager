using System.Collections.Generic;
using AutoMapper;
using Blog.Dal.Models;
using Blog.Dal.Models.Base;

namespace Blog.Bll.Dto
{
    public class BlogDtoPaged
    {
        public int Page {get;set;}
        public List<BlogDto> Blogs { get; set; }
        public int Size {get; set;}
        public int Count {get; set;}

        public BlogDtoPaged(){

        }

        public BlogDtoPaged(IMapper mapper,PagedEntity<BlogEntity> result,int page,int size)
        {
            var blogs = result.Entities;
           
            this.Page = page;
            this.Size = size;
            this.Count = result.Count;
            
            var blogsDto = new List<BlogDto>();

            foreach(var blog in blogs){
                blogsDto.Add(mapper.Map<BlogEntity,BlogDto>(blog));
            }

            this.Blogs = blogsDto;
        }
    }
}