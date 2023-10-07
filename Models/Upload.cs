using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Artbase.Models
{
    public class Upload
    {
        [BsonId]
        public ObjectId _id {  get; set; }
        public string? fileUrl { get; set; }
        public string? UserID {  get; set; }

        public Upload() { }
        public Upload(string? fileUrl, string? userID)
        {
            _id = ObjectId.GenerateNewId();
            this.fileUrl = fileUrl;
            UserID = userID;
        }
    }
}
