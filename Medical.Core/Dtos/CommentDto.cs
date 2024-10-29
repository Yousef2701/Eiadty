using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    public class CommentDto
    {

        [Required]
        public string? PostId { get; set; } = null;

        [Required]
        public string PatientPhone { get; set; }

        [Required]
        public string? Comment_Text { get; set; } = null;
    }
}
