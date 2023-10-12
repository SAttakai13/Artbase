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

        public async Task CreatePost(Post post) =>
            await _postCollection.InsertOneAsync(post);

        public async Task DeletePost(string? postId) => 
            await _postCollection.DeleteOneAsync(x => x.Id == postId);

        public async Task EditPost(string? postId, Post post) =>
            await _postCollection.ReplaceOneAsync(postId, post);


        public async Task<Post> GetPostById(string? postId) => 
            await _postCollection.Find(x=>x.Id == postId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Post>> GetPosts() =>
            await _postCollection.Find(_ => true).ToListAsync();


        //Filtering through the list will be used elsewhere, currently having issues with doing the filtering.
        public Task<IEnumerable<Post>> GetPostsByPostId(string? postId)
        {
            throw new NotImplementedException();
        }
    }
}
