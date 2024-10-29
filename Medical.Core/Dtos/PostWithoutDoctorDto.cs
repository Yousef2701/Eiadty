using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class PostWithoutDoctorDto
    {
        public string? PostId { get; set; } = null;

        [Required]
        public string? Text { get; set; } = null;

        [Required]
        public string? PostType { get; set; } = null;

        [Required]
        public string? Date { get; set; } = null;

        [Required]
        public string? Time { get; set; } = null;

        [Required]
        public string? Am_Pm { get; set; } = null;

        [Required]
        public string? DoctorPhone { get; set; } = null;
    }
}
