using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace Artbase.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Message { get; set; }

        public string? ImageUrl { get; set; }

        public string? UserId { get; set; }

        public Post() { }
        public Post(string? message, string? imageUrl)
        {
            Message = message;
            ImageUrl = imageUrl;
        }
    }
}
