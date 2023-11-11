
using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class FileUpload
    {
        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "File")]
        public IFormFile File { get; set; }    

    }
}
