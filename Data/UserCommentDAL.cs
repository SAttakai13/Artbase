using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserCommentDAL : IUserComment
    {
        private readonly IMongoCollection<Comment> _commentCollection;

        public UserCommentDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _commentCollection = mongoDatabase.GetCollection<Comment>(
                artbaseSettings.Value.CommentsCollectionName);
        }
    }
}
