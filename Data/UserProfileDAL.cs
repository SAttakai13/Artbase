using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserProfileDAL : IUserProfile
    {
        private readonly IMongoCollection<Profile> _profileCollection;

        public UserProfileDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _profileCollection = mongoDatabase.GetCollection<Profile>(
                artbaseSettings.Value.ProfileCollectionName);
        }

        public async Task AddProfile(Profile profile) => 
            await _profileCollection.InsertOneAsync(profile);

        public async Task DeleteProfile(string? profileid) =>
            await _profileCollection.DeleteOneAsync(x => x.Id == profileid);

        public async Task EditProfile(string? profileid, Profile profile) =>
            await _profileCollection.ReplaceOneAsync(profileid, profile);

        public async Task<IEnumerable<Profile>> GetProfile() =>
            await _profileCollection.Find(_ => true).ToListAsync();

        public async Task<Profile> GetProfileByUserId(string? profileid) =>
            await _profileCollection.Find(x => x.UserId == profileid).FirstOrDefaultAsync();



        //Filtering through the list will be used elsewhere, currently having issues with doing the filtering.
        public Task<IEnumerable<Profile>> SearchProfiles(string? name)
        {
            throw new NotImplementedException();
        }


    }
}
