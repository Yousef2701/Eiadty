using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class CheckDto
    {
        [ForeignKey("Book")]
        public int Book_Numbre { get; set; }

        [Required]
        [MaxLength(250)]
        public string Complaint { get; set; }

        [ForeignKey("Doctor")]
        public string Doctor_Phone { get; set; }

        public string Doctor_Name { get; set; }

        public string clinic { get; set; }

        [ForeignKey("Patient")]
        public string Patient_Phone { get; set; }

        public string Patient_Name { get; set; }

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
    }
}
