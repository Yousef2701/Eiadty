using Ganss.XSS;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Core.Dtos
{
    public class DoctorDto
    {

        private string governrate;

        private string city;

        private string adreess;

        private string department;

        private string scienceDegree;

        [Required]
        [RegularExpression("^01[0125][0-9]{8}$",
            ErrorMessage = "Phone Numbre Must Contain only Numbers And Must Start By 010 or 011 or 012 or 015")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Numbre Must Be 11 Number")]
        public string? Phone { get; set; } = null;

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "Name Must Contain only Letters")]
        [StringLength(35,MinimumLength = 7,ErrorMessage ="Name Must Be More Than 7 Letters And Less Than 35 Letters")]
        public string? Name { get; set; } = null;

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
            ErrorMessage = "Governrate Must Contain only Letters")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Governrate Must Be More Than 3 Caracters And Less Than 16 Caracters")]
        public string Governrate
        {
            get => governrate;
            set => governrate = new HtmlSanitizer().Sanitize(value);
        }

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "City Must Contain only Letters")]
        [StringLength(36, MinimumLength = 3, ErrorMessage = "City Must Be More Than 3 Caracters And Less Than 36 Caracters")]
        public string City
        {
            get => city;
            set => city = new HtmlSanitizer().Sanitize(value);
        }

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "Adreess Must Contain Letters And Numbers")]
        [StringLength(70, MinimumLength = 8, ErrorMessage = "Adreess Must Be More Than 8 Caracters And Less Than 70 Caracters")]
        public string Adreess
        {
            get => adreess;
            set => adreess = new HtmlSanitizer().Sanitize(value);
        }

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "Department Must Contain only Letters")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Department Must Be More Than 5 Caracters And Less Than 40 Caracters")]
        public string Department
        {
            get => department;
            set => department = new HtmlSanitizer().Sanitize(value);
        }

        [Required]
        [RegularExpression("^[ا-ي ء أ ؤ]+$*[ؤ ء أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "ScienceDegree Must Contain only Letters")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "ScienceDegree Must Be More Than 5 Caracters And Less Than 70 Caracters")]
        public string ScienceDegree
        {
            get => scienceDegree;
            set => scienceDegree = new HtmlSanitizer().Sanitize(value);
        }

        [Required]
        [RegularExpression("^[ء ؤ أ ا-ي]+[ؤ ء أ ا-ي]*$",
            ErrorMessage = "FromDay Must Contain only Letters")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "FromDay Must Be More Than 5 Caracters And Less Than 10 Caracters")]
        public string? FromDay { get; set; } = null;

        [Required]
        [RegularExpression("^[ء ؤ أ ا-ي]+[ء ؤ أ ا-ي]*$",
            ErrorMessage = "ToDay Must Contain only Letters")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "ToDay Must Be More Than 5 Caracters And Less Than 10 Caracters")]
        public string? ToDay { get; set; } = null;

        [Required]
        [RegularExpression("^[0-9]+[0-9]+[:]+[0-9]+[ ]+[ا-ي ء ؤ أ]*$",
            ErrorMessage = "FromHour Must Contain Letters And Numbers")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "FromHour Must Be More Than 5 Caracters And Less Than 11 Caracters")]
        public string? FromHour { get; set; } = null;

        [Required]
        [RegularExpression("^[0-9]+[0-9]+[:]+[0-9]+[ ]+[ء ؤ أ ا-ي]*$",
            ErrorMessage = "ToHour Must Contain Letters And Numbers")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "ToHour Must Be More Than 5 Caracters And Less Than 11 Caracters")]
        public string? ToHour { get; set; } = null;

        [Required]
        public double NewCheckPrie { get; set; }

        [Required]
        public double ReCheckPrie { get; set; }

        [AllowNull]
        public bool? IsActive { get; set; }

        [AllowNull]
        public IFormFile? image { get; set; }
    }
}
