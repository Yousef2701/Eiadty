using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class GetCommentsDto
    {
        public int Number { get; set; }

        [Required]
        public string? PostId { get; set; } = null;

        [Required]
        public string PatientPhone { get; set; }

        public string PatientName { get; set; }

        [Required]
        public string? Comment_Text { get; set; } = null;
    }
}
