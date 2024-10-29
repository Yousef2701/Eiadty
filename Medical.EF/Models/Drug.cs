using Medical.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Drug
    {
        [Required]
        [ForeignKey("Patient")]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        public string Drug_Name { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
