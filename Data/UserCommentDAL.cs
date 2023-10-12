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

        public async Task AddComment(Comment comment) =>
            await _commentCollection.InsertOneAsync(comment);

        public async Task DeleteComment(string? commentId) => 
            await _commentCollection.DeleteOneAsync(x => x.Id == commentId);

        public async Task EditComment(string? commentId, Comment comment) => 
            await _commentCollection.ReplaceOneAsync(commentId, comment);

        public async Task<Comment> GetCommentByUserId(string? commentid) =>
            await _commentCollection.Find(x => x.Id == commentid).FirstOrDefaultAsync();

        public async Task<IEnumerable<Comment>> GetComments()=>
            await _commentCollection.Find(_ => true).ToListAsync();


        //Filter and bringing back a list of comments based on the post id, having trouble with that
        public Task<IEnumerable<Comment>> SearchCommentsByPostId(string? postname)
        {
            throw new NotImplementedException();
        }
    }
}
