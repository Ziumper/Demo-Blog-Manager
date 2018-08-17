using Blog.Bll.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bll.Services.Comments
{
    public interface ICommentService
    {
        CommentDto DeleteComment(int commentId);
        CommentDto EditComment(CommentDto commentDto);
        List<CommentDto> GetAllCommentsByPostId(int postId);
        CommentDto GetCommentById(int id);
        List<CommentDto> AddCommentToPost(CommentCreateDto commentDto);
    }
}
