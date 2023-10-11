using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserProfile
    {
        Task AddProfile(Comment comment);
        Task DeleteProfile(string? commentId);
        Task EditProfile(string? commentId, Comment comment);
        Task<IEnumerable<Comment>> GetProfile();
        Task<IEnumerable<Comment>> SearchProfiles(string? name);
        Task<Comment> GetProfileByUserId(string? commentid);
    }
}
