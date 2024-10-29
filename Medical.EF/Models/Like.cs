using Medical.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Like
    {
        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public string Patient_Phone { get; set; }

        public virtual Post Post { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
