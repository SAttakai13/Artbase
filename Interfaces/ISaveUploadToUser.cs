using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface ISaveUploadToUser
    {
        void SaveUpload(UserSaves saveUpload);
        void DeleteSavedUpload(int? id);
        IEnumerable<UserSaves> GetAllSavedUploads();
        IEnumerable<UserSaves> GetSavedUploadForUser(string? userid);
        UserSaves GetSavedUploadById(int? id);
        UserSaves GetSaveUploadByUserAndId(string? userid, int? id);
        
    }
}
