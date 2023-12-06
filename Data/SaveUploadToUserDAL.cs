﻿using Artbase.Interfaces;
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

        public IEnumerable<UserSaves> GetAllSavedUploads()
        {
            return db.UserSaves.ToList();
        }

        public UserSaves GetSavedUploadById(int? id)
        {
            UserSaves? foundSaveUploadToUser = db.UserSaves.Where(p => p.SavedId == id).FirstOrDefault();
            return foundSaveUploadToUser;
        }

        public IEnumerable<UserSaves> GetSavedUploadForUser(string? userid)
        {
            if (userid == null)
                userid = "";

            if (userid == "")
                GetAllSavedUploads();

            IEnumerable<UserSaves> lstSavedUserUploads = GetAllSavedUploads().Where(p => p.UserId == userid).ToList();

            if (lstSavedUserUploads.Count() == 0)
            {
                return null;
            }

            return lstSavedUserUploads;
        }

        public bool GetSaveUploadByUserAndId(string? userid, int? uploadid)
        {
            bool checkisin = false;
            if (userid == null)
                userid = "";

            if (uploadid == null)
                uploadid = 0;

            if (userid == "" || uploadid == 0)
                return checkisin;

            UserSaves? foundUniSave = GetAllSavedUploads().Where(p => p.UserId == userid).Where(p => p.UploadId == uploadid).FirstOrDefault();

            if (foundUniSave != null)
            {
                checkisin = true;
                return checkisin;
            }
            return checkisin;
            
        }

        public void SaveUpload(UserSaves saveUpload)
        {
            db.UserSaves.Add(saveUpload);
            db.SaveChanges();
        }
    }
}
