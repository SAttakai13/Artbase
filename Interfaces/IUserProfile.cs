using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserProfile
    {
        Task AddProfile(Profile profile);
        Task DeleteProfile(string? profileid);
        Task EditProfile(string? profileid, Profile profile);
        Task<IEnumerable<Profile>> GetProfile();
        Task<IEnumerable<Profile>> SearchProfiles(string? name);
        Task<Profile> GetProfileByUserId(string? profileid);
    }
}
