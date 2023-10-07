using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Comment
    {
        [BsonId]
        public ObjectId _id {  get; set; }

        [Required(ErrorMessage = "Message can't be empty, otherwise cancel")]
        public string message { get; set; }

        public string? PostID { get; set; }

        public string? UserCommentID { get; set; }

        public Comment() { }
        public Comment(string message, string? postID, string? userCommentID)
        {
            _id = ObjectId.GenerateNewId();
            this.message = message;
            PostID = postID;
            UserCommentID = userCommentID;
        }
    }
}
