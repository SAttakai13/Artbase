using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserUpload
    {
        void AddUpload(Upload upload);
        void DeleteUpload(string? userId);
        IEnumerable<Upload> GetUploads();
        IEnumerable<Upload> GetAllUploadsByUserId(string? userid);

        Upload GetUploadByUploadId(string? uploadId);
    }
}
