using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Ray
    {
        [Key]
        public int Numbre { get; set; }

        [Required]
        [ForeignKey("Check")]
        public int Book_Numbre { get; set; }

        [Required]
        public string Ray_Url { get; set; }

        [Required]
        [MaxLength(350)]
        public string Notes { get; set; }

        public virtual Check Check { get; set; } = null!;

    }
}
