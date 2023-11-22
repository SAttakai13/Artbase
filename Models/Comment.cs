using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Comment
    {
        [Key]
        public int? CommentId { get; set; }


        [Required(ErrorMessage = "Message can't be empty, otherwise cancel")]
        public string message { get; set; }

        public int? PostID { get; set; }

        public string? UserCommentID { get; set; }

        public Comment() { }
        public Comment(string message, int? postID, string? userCommentID)
        {
            this.message = message;
            this.PostID = postID;
            this.UserCommentID = userCommentID;
        }
    }
}
