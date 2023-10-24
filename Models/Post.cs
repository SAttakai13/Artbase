using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

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
