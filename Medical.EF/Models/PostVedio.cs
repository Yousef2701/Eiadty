using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Models
{
    public class PostVedio
    {
        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        public string Vedio_Url { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
