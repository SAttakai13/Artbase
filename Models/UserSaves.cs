using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class UserSaves
    {
        [Key]
        public int SavedId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [MaxLength(450)]
        public string UserId { get; set; }

        [Required]
        public int UploadId { get; set; }

        public UserSaves() { }
        public UserSaves(int uploadId, string userId)
        {
            this.UploadId = uploadId;
            this.UserId = userId;
        }
    }
}
