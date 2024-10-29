using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class PatientDto
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

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "Name Must Contain only Letters")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Name Must Be More Than 3 Caracters And Less Than 16 Caracters")]
        public string? FName { get; set; } = null;

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "Name Must Contain only Letters")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Name Must Be More Than 3 Caracters And Less Than 16 Caracters")]
        public string? LName { get; set; } = null;

        [Required]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "BirthDate Must Be 10 Caracters")]
        public string? BirthDate { get; set; } = null;

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public bool Smoke { get; set; }
    }
}
