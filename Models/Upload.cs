using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Upload
    {

        [Key]
        public int? UploadId { get; set; }

        
        public string? fileUrl { get; set; }
        public byte[] fileContent { get; set; }


        
        public string? UserID {  get; set; }

        public Upload() { }
        public Upload(string? fileUrl, string? userID)
        {            
            this.fileUrl = fileUrl;
            this.UserID = userID;
        }
    }
}
