using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Analysis
    {
        [Key]
        public int Numbre { get; set; }

        [Required]
        [ForeignKey("Check")]
        public int Book_Numbre { get; set; }

        [Required]
        public string Analysis_Url { get; set; }

        [Required]
        [MaxLength(350)]
        public string Notes { get; set; }

        public virtual Check Check { get; set; } = null!;
    }
}
