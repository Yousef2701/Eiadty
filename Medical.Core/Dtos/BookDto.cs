using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class BookDto
    {
        [Required]
        [MaxLength(11)]
        public string Doctor_Phone { get; set; }

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

        //[Required]
        //[MaxLength(2)]
        //public string Am_Pm { get; set; }

        [Required]
        [MaxLength(35)]
        public string Book_Type { get; set; }

        //[Required]
        //public double price { get; set; }
    }
}
