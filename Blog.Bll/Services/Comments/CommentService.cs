using AutoMapper;
using Blog.Bll.Dto;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public CommentDto DeleteComment(int commentId)
        {
           
            var result = _commentRepository.FindBy(c => c.Id == commentId).FirstOrDefault();
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
            result.Date = DateTime.Now;

            _commentRepository.Save();

            var resutlDto = _mapper.Map<Comment, CommentDto>(result);

            return resutlDto;
        }

        public List<CommentDto> GetAllCommentsByPostId(int postId)
        {
            var result = _commentRepository.FindBy(c => c.PostId == postId);

            var commentsDtoList = new List<CommentDto>();
            foreach(var c in result)
            {
                commentsDtoList.Add(_mapper.Map<Comment, CommentDto>(c));
            }

            var resultDtoList = commentsDtoList;
            return resultDtoList;
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

        public List<CommentDto> AddCommentToPost(CommentCreateDto commentDto)
        {
            var comment = _mapper.Map<CommentCreateDto, Comment>(commentDto);

            var postResult = _postRepository.FindByWithComments(x => x.Id == commentDto.PostId).FirstOrDefault();
            if (postResult == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }

            comment.Date = DateTime.Now;

            if (postResult.Comments == null)
            {
                postResult.Comments = new List<Comment>();
            }

            postResult.Comments.Add(comment);
            _postRepository.Save();

            var comments = postResult.Comments;

            var commentsDto = new List<CommentDto>();

            foreach (var c in comments)
            {
                commentsDto.Add(_mapper.Map<Comment, CommentDto>(c));
            }

            return commentsDto;
        }
    }
}
