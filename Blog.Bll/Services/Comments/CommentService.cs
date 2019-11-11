using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Dto.Comments;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository,IPostRepository postRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> DeleteComment(int commentId)
        {
            var resultQuery = await _commentRepository.FindByAsync(c => c.Id == commentId);
            var result = resultQuery.FirstOrDefault();

            if(result == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }

            _commentRepository.Delete(result);
            _commentRepository.Save();

            var resultDto = _mapper.Map<Comment, CommentDto>(result);

            return resultDto;
        }

        public CommentDto EditComment(CommentDto commentDto)
        {
            var result = _commentRepository.FindBy(c => c.Id == commentDto.CommentId).FirstOrDefault();
            if(result == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }
            
            result.Content = commentDto.Content;

            result.SetModificationTime();

            _commentRepository.Save();

            var resutlDto = _mapper.Map<Comment, CommentDto>(result);

            return resutlDto;
        }


        public CommentDto GetCommentById(int id)
        {
            
            var result = _commentRepository.FindBy(c => c.Id == id).FirstOrDefault();
            if(result == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }

            var resultDto = _mapper.Map<Comment, CommentDto>(result);
            
            return resultDto;
        }

        public async Task<List<CommentDto>> AddCommentToPostAsync(CommentCreateDto commentDto)
        {
            var comment = _mapper.Map<CommentCreateDto, Comment>(commentDto);
            var queryResult = await _postRepository.GetPostByIdWithImagesAsync(commentDto.PostId);
            var postResult = queryResult;
            if (postResult == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }

            if (postResult.Comments == null)
            {
                postResult.Comments = new List<Comment>();
            }

            comment.SetModificationAndCreationTime();
            postResult.Comments.Add(comment);
            postResult.SetModificationTime();
            _postRepository.Save();

            var comments = postResult.Comments;

            var commentsDto = new List<CommentDto>();

            foreach (var c in comments)
            {
                commentsDto.Add(_mapper.Map<Comment, CommentDto>(c));
            }

            return commentsDto;
        }

        public async Task<List<CommentDto>> GetAllCommentsByPostIdAsync(int postId)
        {
            var postQueryResult = await _postRepository.GetPostByIdWithImagesAsync(postId);
            var post = postQueryResult;
            if(post == null) throw new ResourceNotFoundException("Post with id:" + postId+ " not found");

            List<CommentDto> result = new List<CommentDto>();
            foreach(var comment in  post.Comments)
            {
                result.Add(_mapper.Map<Comment,CommentDto>(comment));
            }

            return result;
        }
    }
}
