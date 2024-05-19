using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace meme_api.Entity
{
    public class Meme
    {
        [Required]
        public Guid MemeId { get; set; }
        public string TopCaption { get; set; }
        public string BottomCaption { get; set; }
        [Required]
        public string ImageId { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
