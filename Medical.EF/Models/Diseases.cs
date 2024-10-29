using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Medical.Core.Models;

namespace Medical.EF.Models
{
    public class Diseases
    {
        [Required]
        [ForeignKey("Patient")]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        public string Diseases_Name { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
