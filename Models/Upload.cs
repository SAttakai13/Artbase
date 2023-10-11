using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Artbase.Models
{
    public class Upload
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? fileUrl { get; set; }
        public string? UserID {  get; set; }

        public Upload() { }
        public Upload(string? fileUrl, string? userID)
        {            
            this.fileUrl = fileUrl;
            UserID = userID;
        }
    }
}
