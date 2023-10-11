using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserUpload
    {
        Task AddUpload(Upload upload);
        Task DeleteUpload(string? userId);
        Task<IEnumerable<Upload>> GetUploads();
        Task<IEnumerable<Upload>> GetAllUploadsByUserId(string? userid);

        Task<Upload> GetUploadByUploadId(string? uploadId);
    }
}
