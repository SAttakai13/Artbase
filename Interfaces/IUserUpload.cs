using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserUpload
    {
        void AddUpload(Upload upload);
        void DeleteUpload(int? userId);
        IEnumerable<Upload> GetUploads();
        IEnumerable<Upload> GetAllUploadsByUser(string? userid);

        Upload GetUploadById(int? uploadId);
    }
}
