using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Core.Models
{
    public class Comment
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        public string Comment_Text { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public string PatientPhone { get; set; }

        public virtual Post Post { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
