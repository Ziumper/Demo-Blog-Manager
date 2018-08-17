using Blog.Bll.Dto;
using Blog.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bll.Services.Posts
{
    public interface IPostService
    {
        PostDto AddPost(PostCreateDto post);
        PostDto GetPostById(int postId);
        List<PostDto> GetAllPosts();
        PostDto DeletePost(int postId);
        PostDto EditPost(PostDto postDto);
        PostDtoWithComments GetPostWithCommentsById(int postId);
    }
}
