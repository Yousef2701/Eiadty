using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class DrugDto
    {
        [Required]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        [Required]
        public string Drug_Name { get; set; }
    }
}
