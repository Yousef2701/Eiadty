using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class OperationDto
    {
        [Required]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        [Required]
        public string Operation_Name { get; set; }
    }
}
