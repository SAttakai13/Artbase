using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserUploadDAL : IUserUpload
    {
        private readonly IMongoCollection<Upload> _uploadCollection;

        public UserUploadDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _uploadCollection = mongoDatabase.GetCollection<Upload>(
                artbaseSettings.Value.UploadsCollectionName);
        }
    }
}
