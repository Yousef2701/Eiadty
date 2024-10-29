using Medical.EF.Models;
using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Models
{
    public class Patient
    {
        [Key]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(35)]
        public string FName { get; set; }

        [Required]
        [MaxLength(35)]
        public string LName { get; set; }

        [Required]
        [MaxLength(10)]
        public string BirthDate { get; set; }

        [Required]
        public bool IsMale { get; set; }

        public bool Smoke { get; set; }


        public virtual ICollection<Book> Books { get; } = new List<Book>();

        public virtual ICollection<Check> Checks { get; } = new List<Check>();
    }
}
