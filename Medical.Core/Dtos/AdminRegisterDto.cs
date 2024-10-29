using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class AdminRegisterDto
    {
        [Required]
        [RegularExpression("^01[0125][0-9]{8}$",
            ErrorMessage = "Phone Numbre Must Contain only Numbers And Must Start By 010 or 011 or 012 or 015")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Numbre Must Be 11 Number")]

        public string? Phone { get; set; } = null;

        [Required]
        [RegularExpression("^[0-9]+[0-9a-zA-Z]*$",
            ErrorMessage = "Password Must Start By Number And Contain Numbers And Letters")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password Numbre Must Be More Than 8 Caracters And Less Than 16 Caracters")]
        public string? Password { get; set; } = null;

        [Required]
        [RegularExpression("^[0-9]+[0-9a-zA-Z]*$",
            ErrorMessage = "Password Must Start By Number And Contain Numbers And Letters")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password Numbre Must Be More Than 8 Caracters And Less Than 16 Caracters")]
        public string? CheckPassword { get; set; } = null;
    }
}
