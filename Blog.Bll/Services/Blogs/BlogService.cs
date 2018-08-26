using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;

namespace Blog.Bll.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper,ICommentRepository commentRepositry, IPostRepository postRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _commentRepository = commentRepositry;
            _postRepository = postRepository;
        }

        public async Task<BlogDto> AddBlogAsync(BlogCreateDto blog)
        {
            var blogEntity = _mapper.Map<BlogCreateDto,BlogEntity>(blog);
            var result = await _blogRepository.AddAsync(blogEntity);
            
            var resultDto = _mapper.Map<BlogEntity,BlogDto> (result);

            await _blogRepository.SaveAsync();

            return resultDto;
        }

        public async Task<BlogDto> DeleteBlogAsyncById(int id)
        {
            var blog = await _blogRepository.GetBlogByIdWithPosts(id);
            if(blog == null) throw new ResourceNotFoundException("Blog with this Id is not found");
            
            foreach(var post in blog.Posts)
            {
                var postWithComments = _postRepository.FindByWithComments(p => p.PostId == post.PostId).FirstOrDefault();
                var isComments = postWithComments.Comments.Count > 0;
                if(isComments) _commentRepository.DeleteMany(postWithComments.Comments);
                _postRepository.Delete(post);
            }
            
            var result = _blogRepository.Delete(blog);

            var resultDto = _mapper.Map<BlogEntity,BlogDto> (result);

            await _blogRepository.SaveAsync();

            return resultDto;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            var blogsDto = new List<BlogDto>();

            foreach(var blog in blogs)
            {
                blogsDto.Add(_mapper.Map<BlogEntity,BlogDto>(blog));
            }

            return blogsDto;
        }

        public async Task<BlogDto> GetBlogByIdAsync(int id)
        {
            var blog = await _blogRepository.FindByFirstAsync(b => b.BlogEntityId == id);
            if(blog == null) throw new ResourceNotFoundException("Blog with Id " + id + " not found");
            var blogDto = _mapper.Map<BlogEntity,BlogDto>(blog);
            return blogDto;
        }
    }
}
