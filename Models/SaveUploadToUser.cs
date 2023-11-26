using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class SaveUploadToUser
    {
        [Key]
        public int? SavdId { get; set; }
        [Required]
        public string? UserId { get; set; }

        [Required]
        public int? UploadId { get; set; }

        public SaveUploadToUser() { }
        public SaveUploadToUser(int? savdId, string userId)
        {
            this.SavdId = savdId;
            this.UserId = userId;
        }
    }
}
