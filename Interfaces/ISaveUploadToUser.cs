using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface ISaveUploadToUser
    {
        void SaveUpload(SaveUploadToUser saveUpload);
        void DeleteSavedUpload(int? id);
        IEnumerable<SaveUploadToUser> GetAllSavedUploads();
        IEnumerable<SaveUploadToUser> GetSavedUploadForUser(string? userid);
        SaveUploadToUser GetSavedUploadById(int? id);
        SaveUploadToUser GetSaveUploadByUserAndId(string? userid, int? id);
        
    }
}
