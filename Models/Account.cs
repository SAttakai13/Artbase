using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Account
    {

        //Rough idea of the Account process, currently researching user account login structures will be subject to change as the project progresses
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserName")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [BsonElement("PassWord")] //this will just be storing the Hashed Version of the password.
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [BsonElement("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [BsonElement]
        public bool? EmailVerified { get; set;}


        public Account() { }
        public Account(string userName, string password, string email, bool? emailVerified)
        {
            UserName = userName;
            Password = password;
            Email = email;
            EmailVerified = emailVerified;
        }
    }
}
