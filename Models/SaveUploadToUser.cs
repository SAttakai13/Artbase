using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class SaveUploadToUser
    {
        [Key]
        public int SavedId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public int? UploadId { get; set; }

        public SaveUploadToUser() { }
        public SaveUploadToUser(int? uploadId, string userId)
        {
            this.UploadId = uploadId;
            this.UserId = userId;
        }
    }
}
