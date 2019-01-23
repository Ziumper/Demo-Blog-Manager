using System;
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
using Blog.Dal.Repositories.Tags;

namespace Blog.Bll.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IImageWriter _imageWriter;

        public PostService(IPostRepository postRepository,
        IBlogRepository blogRepository, 
        ICommentRepository commentRepository,
        ITagRepository tagRepository,
        IMapper mapper,
        IImageRepository imageRepository,
        IImageWriter imageWriter)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
            _blogRepository = blogRepository;
            _tagRepository = tagRepository;
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

            List<Tag> entityTags = await AddTagsFromPostsList(post.PostTags);

            var image = await _imageRepository.FindByFirstAsync(img => img.Id == post.MainImage.Id);

            var images = await GetImagesForPost(post);

            var mappedPost = _mapper.Map<PostDto,Post>(post);

            mappedPost.MainImage = image;
            mappedPost.Images = images;

            mappedPost.PostTags = new List<PostTag>();
            mappedPost = AssignPostTagsToPostEntity(mappedPost,entityTags);

            var result = await _postRepository.AddAsync(mappedPost);
            await _postRepository.SaveAsync();

            var resultDto = _mapper.Map<Post,PostDto>(result);

            return resultDto;
        }

        private async Task<List<Image>> GetImagesForPost(PostDto post) {

            List<Image> images = new List<Image>();
            
            foreach (var imageDto in post.Images) {
                var imageFromBase = await _imageRepository.FindByFirstAsync(image => image.Id == imageDto.Id);
                images.Add(imageFromBase);
            }

            return images;
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



            _commentRepository.DeleteManyCommentsByPostId(postId);
            await _commentRepository.SaveAsync();

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

            var post = await _postRepository.GetPostByIdWithPostTagsAsync(postDto.Id);
            bool postFound = post != null;
            if(!postFound)
            {
                throw new ResourceNotFoundException("Post not found");
            }

            post.Content = postDto.Content;
            post.Title = postDto.Title;

            var entityTags = await AddTagsFromPostsList(postDto.PostTags);
            post = AssignPostTagsToPostEntity(post,entityTags);

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

        public async Task<PostDtoWithComments> GetPostWithCommentsByIdAsync(int postId)
        {
            var awaitResult = await _postRepository.FindByWithCommentsAsyncWithTags(p => p.Id == postId);
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

            var result = await _postRepository.GetPostsPagedWithTagsAsync(
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

        private Post AssignPostTagsToPostEntity(Post post,List<Tag> entityTags )
        {
            bool postTagsListInitalized = post.PostTags != null;
    
            for(var i = 0 ; i < entityTags.Count; i++) {
                var postTag = new PostTag();
                var entityTag = entityTags[i];
                postTag.Post = post;
                postTag.PostId = post.Id;
                postTag.Tag = entityTag;
                postTag.TagId = entityTag.Id;
                post.PostTags.Add(postTag);
            }

            return post;
        }

        private async Task<List<Tag>> AddTagsFromPostsList(List<PostTagDto> postTags)
        {
            List<Tag> entityTags = new List<Tag>();

            for(var i =0; i < postTags.Count; i++)
            {
                var myTag = postTags[i];
                var tagFromDatabase = await _tagRepository.FindByFirstAsync(tag => tag.Name.Equals(myTag.Tag.Name));
                bool tagFound = tagFromDatabase != null;
                if(tagFound) {
                    entityTags.Add(tagFromDatabase);
                }
                else {
                    var tagEntity = _mapper.Map<TagDto,Tag>(myTag.Tag);
                    tagEntity = await _tagRepository.AddAsync(tagEntity);     
                    await _tagRepository.SaveAsync();
                    entityTags.Add(tagEntity);
                }
            }

            return entityTags;
        }

        public async Task<PostDto> GetPostByIdWithTagsAsync(int postId)
        {
            var result = await _postRepository.GetPostByIdWithPostTagsAsync(postId);
            if (result == null)
            {
                throw new ResourceNotFoundException("Post not found");
            } 

            var resultDto = _mapper.Map<Post, PostDto>(result);
            return resultDto;
        }

        public async Task<PostDto> GetPostByBlogIdAndPostIdAndWithCommentsAsync(int blogId, int postId)
        {
           var dbResult = await _postRepository.FindByWithCommentsAsyncWithTags(post => post.Id == postId && post.BlogId == post.BlogId);
        
           var dbResultOne = dbResult.FirstOrDefault();
           var resultDto = _mapper.Map<Post,PostDto>(dbResultOne);
           return resultDto;
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
    }
}
