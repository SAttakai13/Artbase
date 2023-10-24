using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Upload
    {

        [Key]
        public int? UploadId { get; set; }

        [Required]
        public string fileUrl { get; set; }


        [Required]
        public string? UserID {  get; set; }

        public Upload() { }
        public Upload(string fileUrl, string? userID)
        {            
            this.fileUrl = fileUrl;
            UserID = userID;
        }
    }
}
