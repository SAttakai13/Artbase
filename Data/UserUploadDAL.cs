using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class UserUploadDAL : IUserUpload
    {
        public void AddUpload(Upload upload)
        {
            throw new NotImplementedException();
        }

        public void DeleteUpload(string? userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Upload> GetAllUploadsByUserId(string? userid)
        {
            throw new NotImplementedException();
        }

        public Upload GetUploadByUploadId(string? uploadId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Upload> GetUploads()
        {
            throw new NotImplementedException();
        }
    }
}
