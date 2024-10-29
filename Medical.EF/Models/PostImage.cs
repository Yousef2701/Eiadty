using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Core.Models
{
    public class PostImage
    {
        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        public string Image_Url { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
