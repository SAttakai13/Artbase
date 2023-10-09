using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserComment
    {
        void AddComment(Comment comment);
        void DeleteComment(string? commentId);
        void EditComment(Comment comment);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> SearchComments(string? name);
        Comment GetCommentByUserId(string? commentid);
    }
}
