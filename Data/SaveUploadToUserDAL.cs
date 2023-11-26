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
            SaveUploadToUser? foundSaveUploadToUser = db.UserSaves.Where(p => p.SavdId == id).FirstOrDefault();
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

        public void SaveUpload(SaveUploadToUser saveUpload)
        {
            db.UserSaves.Add(saveUpload);
            db.SaveChanges();
        }
    }
}
