using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class DiseasesDto
    {
        [Required]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        [Required]
        public string Diseases_Name { get; set; }
    }
}
