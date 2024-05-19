using System.ComponentModel.DataAnnotations;

namespace meme_api.Models
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
