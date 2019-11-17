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
        Task<PostDto> AddPostAsync(PostDto post);
        Task<PostDto> GetPostById(int postId);
        Task<PostDto> GetPostByIdWithTagsAsync(int postId);
        List<PostDto> GetAllPosts();
        PostDto DeletePost(int postId);
        Task<PostDto> DeletePostAsync(int postId);
        PostDto EditPost(PostDto postDto);
        Task<PostDto> EditPostAsync(PostDto postDto);
        Task<PostDtoWithComments> GetPostWithCommentsByIdAsync(int postId);
        Task<PostDtoPaged> GetAllPostsPagedAsync(PostQuery searchQuery);
        Task<PostDtoPaged> GetAllPostPagedAsyncByBlogId(PostQuery searchQuery);
        Task<PostDtoPaged> GetAllPostsPagedASyncByTags(PostQuery query);
        Task<PostDtoPaged> GetAllPostPagedAsyncByBlogIdAndTagsId(PostQuery query);
        Task<List<PostDto>> GetPostsByContentOrTitleAsync(string content);
    }
}
