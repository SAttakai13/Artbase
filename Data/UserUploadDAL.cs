using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace Artbase.Data
{
    public class UserUploadDAL : IUserUpload
    {
        private AppDbContext db;

        public UserUploadDAL(AppDbContext artbaseSettings)
        {
            this.db = artbaseSettings;
        }

        public void AddUpload(Upload upload)
        {
            throw new NotImplementedException();
        }

        public void DeleteUpload(int? userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Upload> GetAllUploadsByUser(string? userid)
        {
            if (userid == null)
                userid = "";

            if (userid == "")
                GetUploads();

            IEnumerable<Upload> lstUserUploads = GetUploads().Where(p => p.UserID.Contains(userid));

            if (lstUserUploads.Count() == 0)
            {
                return GetUploads();
            }

            return lstUserUploads;
        }

        public IEnumerable<Upload> GetUploads()
        {
            return db.Uploads.ToList();
        }
        public Upload GetUploadById(int? uploadId)
        {
            Upload? foundUpload = db.Uploads.Where(p => p.UploadId == uploadId).FirstOrDefault();
            return foundUpload;
        }
    }
}
