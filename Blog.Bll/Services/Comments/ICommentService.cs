using Blog.Bll.Dto;
using Blog.Bll.Dto.Comments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.Services.Comments
{
    public interface ICommentService
    {
        CommentDto DeleteComment(int commentId);
        CommentDto EditComment(CommentDto commentDto);
        Task<List<CommentDto>> GetAllCommentsByPostIdAsync(int postId);
        CommentDto GetCommentById(int id);
        Task<List<CommentDto>> AddCommentToPostAsync(CommentCreateDto commentDto);
    }
}
