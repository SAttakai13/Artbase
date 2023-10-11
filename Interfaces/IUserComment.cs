using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserComment
    {
        Task AddComment(Comment comment);
        Task DeleteComment(string? commentId);
        Task EditComment(string? commentId, Comment comment);
        Task<IEnumerable<Comment>> GetComments();
        Task<IEnumerable<Comment>> SearchComments(string? name);
        Task<Comment> GetCommentByUserId(string? commentid);
    }
}
