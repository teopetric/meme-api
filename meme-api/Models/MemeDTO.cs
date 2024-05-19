using System.ComponentModel.DataAnnotations;

namespace meme_api.Models
{
    public class MemeDTO
    {
        public Guid? MemeId { get; set; }
        public string TopCaption { get; set; }
        public string BottomCaption { get; set; }
        [Required]
        public string ImageId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
