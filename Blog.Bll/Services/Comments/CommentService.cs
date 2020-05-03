using AutoMapper;
using Blog.Bll.Dto.Comments;
using Blog.Bll.Exceptions;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;
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

        public async Task<CommentDto> EditComment(CommentDto commentDto)
        {
            var result = _commentRepository.FindBy(c => c.Id == commentDto.Id).FirstOrDefault();
            if(result == null)
            {
                throw new ResourceNotFoundException("Comment not found");
            }
            
            result.Content = commentDto.Content;

            result.SetModificationTime();

            await _commentRepository.SaveAsync();

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
            var queryResult = await _postRepository.FindByIdFirstAsync(commentDto.PostId);
            var postResult = queryResult;
            if (postResult == null)
            {
                throw new ResourceNotFoundException("Post not found");
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

        public async Task<List<CommentDto>> GetComments(CommentsQueryDto query)
        {
            var comments = await this._commentRepository.GetCommentsByPostId(query.PostId,query.Take,query.Skip);
            return _mapper.Map<List<Comment>,List<CommentDto>>(comments);
        }

        public async Task<int> GetCountCommentsByPostId(int postId)
        {
            return await this._commentRepository.GetCommentsCountByPostId(postId);
        }
    }
}
