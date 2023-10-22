using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class AccountUser : MongoIdentityUser<Guid>
    {

        
    }
}
