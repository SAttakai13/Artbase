using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserComment
    {
        void AddComment(Comment comment);
        void DeleteComment(int? commentId);
        void EditComment(Comment comment);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentByUser(string? commentid);

        Comment GetCommentById(int? commentId);
    }
}
