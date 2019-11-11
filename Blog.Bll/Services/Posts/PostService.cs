﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Posts;
using Blog.Bll.Dto.QueryModels;
using Blog.Bll.Dto.Tags;
using Blog.Bll.Exceptions;
using Blog.Bll.Services.Images.ImageWriter;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Images;
using Blog.Dal.Repositories.Posts;


namespace Blog.Bll.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;

        private readonly IImageRepository _imageRepository;
        private readonly IImageWriter _imageWriter;

        public PostService(
            IPostRepository postRepository,
            IBlogRepository blogRepository, 
            ICommentRepository commentRepository,
            IMapper mapper,
            IImageRepository imageRepository,
            IImageWriter imageWriter)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
            _blogRepository = blogRepository;
            _imageRepository = imageRepository;
            _imageWriter = imageWriter;
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

            var image = await _imageRepository.FindByFirstAsync(img => img.Id == post.MainImage.Id);
            var mappedPost = _mapper.Map<PostDto,Post>(post);
            mappedPost.MainImage = image;
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

        public async Task<PostDto> DeletePostAsync(int postId)
        {
            
            var result = await _postRepository.GetPostByIdWithImagesAsync(postId);
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            _imageRepository.Delete(result.MainImage);

            _imageWriter.DeleteImageFileFromServer(result.MainImage.Name);

            _commentRepository.DeleteManyCommentsByPostId(postId);
            
            _postRepository.Delete(p => p.Id == postId);
            await _postRepository.SaveAsync();

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
            var image = await _imageRepository.FindByFirstAsync(img => img.Id == postDto.MainImage.Id);
            
            var post = await _postRepository.GetPostByIdWithImagesAsync(postDto.Id);
            bool postFound = post != null;
            if(!postFound)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            post.Content = postDto.Content;
            post.Title = postDto.Title;

            post.MainImage = image;
            post = _postRepository.Edit(post);
            await _postRepository.SaveAsync();
            var resultDto = _mapper.Map<Post, PostDto>(post);
            return resultDto;
        }
            
        public async Task<PostDto> GetPostById(int postId)
        {
            var result = await _postRepository.FindByFirstAsync(p => p.Id == postId);
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            return _mapper.Map<Post, PostDto>(result);
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

        public async Task<List<PostDto>> GetPostsByContentOrTitleAsync(string content)
        {
            var databaseResult = await _postRepository.FindByAsync(post => post.Content.Contains(content) || post.Title.Contains(content),10);

            var resultDto = new List<PostDto>();
            foreach(var dbPost in databaseResult)
            {
                resultDto.Add(_mapper.Map<Post,PostDto>(dbPost));
            }

            return resultDto;
        }

        public Task<PostDto> GetPostByIdWithTagsAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDtoWithComments> GetPostWithCommentsByIdAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDtoPaged> GetAllPostsPagedASyncByTags(PostQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<PostDtoPaged> GetAllPostPagedAsyncByBlogIdAndTagsId(PostQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostByBlogIdAndPostIdAndWithCommentsAsync(int blogId, int postId)
        {
            throw new NotImplementedException();
        }
    }
}
