using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string? BirthDay { get; set; }

        public string? Pronouns { get; set; }

        public string? Bio {  get; set; }

        public string? PostId {  get; set; }

        public string? UserId { get; set; }

        public List<string>? friends { get; set; }


        public Profile() { }
        public Profile(string name, string? birthDay, string? pronouns, string? bio)
        {
            Name = name;
            BirthDay = birthDay;
            Pronouns = pronouns;
            Bio = bio;
        }
    }
}
