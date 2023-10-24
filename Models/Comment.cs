using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Comment
    {
        [Key]
        public int? CommentId { get; set; }


        [Required(ErrorMessage = "Message can't be empty, otherwise cancel")]
        public string message { get; set; }

        public string? PostID { get; set; }

        public string? UserCommentID { get; set; }

        public Comment() { }
        public Comment(string message, string? postID, string? userCommentID)
        {
            this.message = message;
            PostID = postID;
            UserCommentID = userCommentID;
        }
    }
}
