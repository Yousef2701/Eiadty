using Medical.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.EF.Models
{
    public class Check
    {
        [Key]
        [ForeignKey("Book")]
        public int Book_Numbre { get; set; }

        [Required]
        [MaxLength(250)]
        public string Complaint { get; set; }

        [ForeignKey("Doctor")]
        public string Doctor_Phone { get; set; }

        [ForeignKey("Patient")]
        public string Patient_Phone { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [Required]
        [MaxLength(5)]
        public string Time { get; set; }

        [Required]
        [MaxLength(2)]
        public string Am_Pm { get; set; }

        [Required]
        [MaxLength(350)]
        public string Diagnosis { get; set; }

        public string DrugListUrl { get; set; }

        public string RayListUrl { get; set; }

        public string AnalysistListUrl { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

        public virtual ICollection<Ray> Rays { get; } = new List<Ray>();

        public virtual ICollection<Analysis> Analyses { get; } = new List<Analysis>();
    }
}
