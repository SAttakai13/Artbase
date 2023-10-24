using System.ComponentModel.DataAnnotations;

namespace Artbase.Models
{
    public class Profile
    {
        [Key]
        public int? ProfileId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string? BirthDay { get; set; }

        public string? Pronouns { get; set; }

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
