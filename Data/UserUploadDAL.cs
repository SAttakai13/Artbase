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

        public async Task AddUpload(Upload upload) =>
            await _uploadCollection.InsertOneAsync(upload);

        public async Task DeleteUpload(string? uploadId) =>
            await _uploadCollection.DeleteOneAsync(x => x.Id == uploadId);

        //Filtering through the list will be used elsewhere, currently having issues with doing the filtering.
        public Task<IEnumerable<Upload>> GetAllUploadsByUserId(string? userid)
        {
            throw new NotImplementedException();
        }

        public async Task<Upload> GetUploadByUploadId(string? uploadId) =>
            await _uploadCollection.Find(x => x.Id == uploadId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Upload>> GetUploads() =>
            await _uploadCollection.Find(_ => true).ToListAsync();
    }
}
