using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.QueryModels;
using Blog.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Posts
{
    public interface IPostService
    {
        PostDto AddPost(PostDto post);
        Task<PostDto> AddPostAsync(PostDtoWithTags post);
        PostDto GetPostById(int postId);
        List<PostDto> GetAllPosts();
        PostDto DeletePost(int postId);
        PostDto EditPost(PostDto postDto);
        Task<PostDto> EditPostAsync(PostDtoWithTags postDto);
        Task<PostDtoWithComments> GetPostWithCommentsByIdAsync(int postId);
        Task<PostDtoPaged> GetAllPostsPagedAsync(PostQuery searchQuery);
        Task<PostDtoPaged> GetAllPostPagedAsyncByBlogId(PostQuery searchQuery);
        Task<PostDtoPaged> GetAllPostsPagedASyncByTags(PostQuery query);
        Task<PostDtoPaged> GetAllPostPagedAsyncByBlogIdAndTagsId(PostQuery query);
    }
}
