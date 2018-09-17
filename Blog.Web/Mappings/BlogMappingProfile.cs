﻿using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Dto.Blogs;
using Blog.Dal.Models;

namespace Blog.Web.Mappings
{
    public class BlogMappingProfile  : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogCreateDto,BlogEntity>().ForMember(destination => destination.Id,options => options.Ignore()).ForMember(destination => destination.Posts,options => options.Ignore());
            CreateMap<BlogEntity,BlogDto>().ReverseMap();
        }
    }

}
