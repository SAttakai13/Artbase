using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserProfileDAL
    {
        private readonly IMongoCollection<Profile> _profileCollection;

        public UserProfileDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _profileCollection = mongoDatabase.GetCollection<Profile>(
                artbaseSettings.Value.ProfileCollectionName);
        }
    }
}
