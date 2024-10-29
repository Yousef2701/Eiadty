using Medical.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Operation
    {
        [Required]
        [ForeignKey("Patient")]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        public string Operation_Name { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
