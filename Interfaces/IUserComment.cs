using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserComment
    {
        void AddComment(Comment comment);
        void DeleteComment(int? commentId);
        void EditComment(Comment comment);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetAllCommentsByPost(int? postid);
        IEnumerable<Comment> GetCommentByUser(string? userid);

        Comment GetCommentById(int? commentId);
    }
}
