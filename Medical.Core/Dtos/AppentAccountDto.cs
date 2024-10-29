
using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class AppentAccountDto
    {
        [MaxLength(11)]
        [Required]
        public string phone { get; set; }
    }
}
