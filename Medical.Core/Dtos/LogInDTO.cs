using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class LogInDTO
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
