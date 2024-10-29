using System.ComponentModel.DataAnnotations;

namespace Medical.EF.Models
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
