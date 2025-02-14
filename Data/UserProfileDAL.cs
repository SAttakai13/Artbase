﻿using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class UserProfileDAL : IUserProfile
    {
        private AppDbContext db;

        public UserProfileDAL(AppDbContext artbaseSettings)
        {
            this.db = artbaseSettings;
        }

        public void AddProfile(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
        }

        public void DeleteProfile(string? profileuserid)
        {
            var foundprofile = GetProfileByUserId(profileuserid);
            if (foundprofile != null)
            {
                db.Profiles.Remove(foundprofile);
                db.SaveChanges();
            }
        }

        public void EditProfile(Profile profile)
        {
            db.Profiles.Update(profile);
            db.SaveChanges();
        }

        public IEnumerable<Profile> GetProfile()
        {
            return db.Profiles.ToList();
        }

        public IEnumerable<Profile> FilterProfiles(string? name)
        {
            if (name == null)
            {
                name = "";
            }
            if (name == "")
            {
                GetProfile();
            }

            IEnumerable<Profile> LstUserProfiles = GetProfile().Where(p => p.Name.ToLower().Contains(name.ToLower()));
            if (LstUserProfiles.Count() == 0)
            {
                return null;
            }

            return LstUserProfiles;
        }

        public Profile GetProfileById(int? profileid)
        {
            Profile? foundProfile = db.Profiles.Where(p => p.Id == profileid).FirstOrDefault();
            return foundProfile;
        }

        public Profile GetProfileByUserId(string? userid)
        {
            Profile? foundProfile = db.Profiles.Where(p => p.UserId == userid).FirstOrDefault();
            return foundProfile;
        }
    }
}
