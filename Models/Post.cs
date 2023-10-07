using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace Artbase.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string? Message { get; set; }

        public string? ImageUrl { get; set; }

        public string? UserId { get; set; }

        public Post() { }
        public Post(string? message, string? imageUrl)
        {
            _id = ObjectId.GenerateNewId();
            Message = message;
            ImageUrl = imageUrl;
        }
    }
}
