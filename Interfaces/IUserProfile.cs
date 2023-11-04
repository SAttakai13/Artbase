using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserProfile
    {
        void AddProfile(Profile profile);
        void DeleteProfile(int? profileid);
        void EditProfile(Profile profile);
        IEnumerable<Profile> GetProfile();
        
        IEnumerable<Profile> FilterProfiles(string? name);
        Profile GetProfileByUserId(string? userid);
        Profile GetProfileById(int? profileid);
    }
}
