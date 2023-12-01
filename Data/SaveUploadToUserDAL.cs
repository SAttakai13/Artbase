using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class SaveUploadToUserDAL : ISaveUploadToUser
    {
        private AppDbContext db;
        public SaveUploadToUserDAL(AppDbContext db)
        {
            this.db = db;
        }

        public void DeleteSavedUpload(int? id)
        {
            var search = GetSavedUploadById(id);
            if (search != null)
            {
                db.UserSaves.Remove(search);
                db.SaveChanges();
            }
        }

        public IEnumerable<SaveUploadToUser> GetAllSavedUploads()
        {
            return db.UserSaves.ToList();
        }

        public SaveUploadToUser GetSavedUploadById(int? id)
        {
            SaveUploadToUser? foundSaveUploadToUser = db.UserSaves.Where(p => p.SavedId == id).FirstOrDefault();
            return foundSaveUploadToUser;
        }

        public IEnumerable<SaveUploadToUser> GetSavedUploadForUser(string? userid)
        {
            if (userid == null)
                userid = "";

            if (userid == "")
                GetAllSavedUploads();

            IEnumerable<SaveUploadToUser> lstSavedUserUploads = GetAllSavedUploads().Where(p => p.UserId == userid).ToList();

            if (lstSavedUserUploads.Count() == 0)
            {
                return null;
            }

            return lstSavedUserUploads;
        }

        public SaveUploadToUser GetSaveUploadByUserAndId(string? userid, int? uploadid)
        {
            if (userid == null)
                userid = "";

            if (uploadid == null)
                uploadid = 0;

            if (userid == "" || uploadid == 0)
                return null;

            IEnumerable<SaveUploadToUser> lstSavedUserUploads = GetAllSavedUploads().Where(p => p.UserId == userid).ToList();
            SaveUploadToUser? foundUniSave = lstSavedUserUploads.Where(p => p.UploadId == uploadid).FirstOrDefault();

            

            return foundUniSave;
        }

        public void SaveUpload(SaveUploadToUser saveUpload)
        {
            db.UserSaves.Add(saveUpload);
            db.SaveChanges();
        }
    }
}
