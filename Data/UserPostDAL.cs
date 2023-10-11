using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserPostDAL : IUserPost
    {
        private readonly IMongoCollection<Post> _postCollection;

        public UserPostDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _postCollection = mongoDatabase.GetCollection<Post>(
                artbaseSettings.Value.PostsCollectionName);
        }
    }
}
