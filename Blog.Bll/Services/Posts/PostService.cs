using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.QueryModels;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;

namespace Blog.Bll.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;

        public PostService(IPostRepository postRepository,
        IBlogRepository blogRepository, ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public PostDto AddPost(PostDto post)
        {
            var mappedPost = _mapper.Map<PostDto, Post>(post);

            mappedPost.Comments = new List<Comment>();
            var result = _postRepository.Add(mappedPost);

            _postRepository.Save();

            var resultDto = _mapper.Map<Post, PostDto>(result);
            return resultDto;
        }

        public async Task<PostDto> AddPostAsync(PostDto post){
            var mappedPost = _mapper.Map<PostDto,Post>(post);
        
            var result = await _postRepository.AddAsync(mappedPost);
            await _postRepository.SaveAsync();

            var resultDto = _mapper.Map<Post,PostDto>(result);

            return resultDto;
        }

        public List<PostDto> GetAllPosts()
        {
           
            var posts = _postRepository.GetAll();
            List<PostDto> postViews = new List<PostDto>();
            foreach(var post in posts)
            {
                postViews.Add(_mapper.Map<Post, PostDto>(post));
            }

            return postViews;
        }

        public PostDto DeletePost(int postId)
        {
           
            var result = _postRepository.FindBy(p => p.Id == postId).FirstOrDefault();
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            } 

            _commentRepository.DeleteManyCommentsByPostId(postId);
            _commentRepository.Save();

            _postRepository.Delete(p => p.Id == postId);
            _postRepository.Save();

            var resultDto = _mapper.Map<Post, PostDto>(result);
            return resultDto;
        }

        public PostDto EditPost(PostDto postDto)
        {
            var result = _postRepository.FindBy(post => post.Id == postDto.Id).FirstOrDefault();
            if(result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }
            result.Content = postDto.Content;
            result.Title = postDto.Title;

            result = _postRepository.Edit(result);
            _postRepository.Save();
            var resultDto = _mapper.Map<Post, PostDto>(result);
            return resultDto;
        }

        public async Task<PostDto> EditPostAsync(PostDto postDto)
        {
            var query = await _postRepository.FindByAsync(post => post.Id == postDto.Id);
            var result = query.FirstOrDefault();
            if(result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }
            result.Content = postDto.Content;
            result.Title = postDto.Title;

            result = _postRepository.Edit(result);
            await _postRepository.SaveAsync();
            var resultDto = _mapper.Map<Post, PostDto>(result);
            return resultDto;
        }
            
        public PostDto GetPostById(int postId)
        {
            var result = _postRepository.FindBy(p => p.Id == postId).FirstOrDefault();
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            return _mapper.Map<Post, PostDto>(result);
        }

        public async Task<PostDtoWithComments> GetPostWithCommentsByIdAsync(int postId)
        {
            var awaitResult = await _postRepository.FindByWithCommentsAsync(p => p.Id == postId);
            var result = awaitResult.FirstOrDefault();
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            return _mapper.Map<Post, PostDtoWithComments>(result);
        }

        public async Task<PostDtoPaged> GetAllPostsPagedAsync(PostQuery searchQuery)
        {
            if(searchQuery.SearchQuery == null) {
                searchQuery.SearchQuery = string.Empty;
            }

            var result = await _postRepository.GetAllPagedAsync(
                searchQuery.Page,searchQuery.Size,searchQuery.Filter,searchQuery.Order,
            x=> x.Title.Contains(searchQuery.SearchQuery) 
            || x.Content.Contains(searchQuery.SearchQuery) 
            || x.ShortDescription.Contains(searchQuery.SearchQuery));

            return new PostDtoPaged(_mapper,result,searchQuery.Page,searchQuery.Size);
        }

        public async Task<PostDtoPaged> GetAllPostPagedAsyncByBlogId(PostQuery postQuery)
        {
             if(postQuery.SearchQuery == null) {
                postQuery.SearchQuery = string.Empty;
            }

            var result = await _postRepository.GetAllPagedAsync(
                postQuery.Page,postQuery.Size,postQuery.Filter,postQuery.Order, 
            p => p.BlogId == postQuery.BlogId && (p.Title.Contains(postQuery.SearchQuery) 
            || p.Content.Contains(postQuery.SearchQuery)
            || p.ShortDescription.Contains(postQuery.SearchQuery))
            );

            return new PostDtoPaged(_mapper,result,postQuery.Page,postQuery.Size);;
           
        }


        public async Task<PostDtoPaged> GetAllPostsPagedASyncByTags(PostQuery query)
        {
            if(query.SearchQuery == null) {
                query.SearchQuery = string.Empty;
            }
            var result = await _postRepository.GetPostsPagedByTags(query.Page,query.Size,query.Filter,query.Order,query.TagsIds, 
            p => (p.Title.Contains(query.SearchQuery) 
            || p.Content.Contains(query.SearchQuery)
            || p.ShortDescription.Contains(query.SearchQuery)));

            return new PostDtoPaged(_mapper,result,query.Page,query.Size);;
        }

        public async Task<PostDtoPaged> GetAllPostPagedAsyncByBlogIdAndTagsId(PostQuery query)
        {
             if(query.SearchQuery == null) {
                query.SearchQuery = string.Empty;
            }

            var result = await _postRepository.GetPostsPagedByTags(query.Page,query.Size,query.Filter,query.Order,query.TagsIds, 
            p => p.BlogId == query.BlogId && (p.Title.Contains(query.SearchQuery) 
            || p.Content.Contains(query.SearchQuery)
            || p.ShortDescription.Contains(query.SearchQuery)));

            return new PostDtoPaged(_mapper,result,query.Page,query.Size);;
        }
    }
}
