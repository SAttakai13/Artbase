using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserProfile
    {
        void AddProfile(Comment comment);
        void DeleteProfile(string? commentId);
        void EditProfile(Comment comment);
        IEnumerable<Comment> GetProfile();
        IEnumerable<Comment> SearchProfiles(string? name);
        Comment GetProfileByUserId(string? commentid);
    }
}
