using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Profile
    {
        [Key]
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please add your name")]
        public string? BirthDay { get; set; }

        [Required(ErrorMessage = "Please input your Pronouns")]
        public string? Pronouns { get; set; }

        [Required(ErrorMessage = "Please add your bio")]
        public string? Bio {  get; set; }

        [MaxLength(450)]
        public string? UserId { get; set; }



        public Profile() { }
        public Profile(string name, string? birthDay, string? pronouns, string? bio)
        {
            Name = name;
            BirthDay = birthDay;
            Pronouns = pronouns;
            Bio = bio;
        }
    }
}
