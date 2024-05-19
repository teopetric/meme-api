using System.ComponentModel.DataAnnotations;

namespace meme_api.Entity
{
    public class User
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<Meme> Memes { get; set; }
    }
}
