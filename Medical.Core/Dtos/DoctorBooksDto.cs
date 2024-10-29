using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class DoctorBooksDto
    {

        public string Book_Numbre { get; set; }

        [Required]
        [MaxLength(11)]
        public string Doctor_Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string Patient_Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        [Required]
        [MaxLength(250)]
        public string Complaint { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [Required]
        [MaxLength(7)]
        public string Time { get; set; }

        [Required]
        [MaxLength(35)]
        public string Book_Type { get; set; }

    }
}
