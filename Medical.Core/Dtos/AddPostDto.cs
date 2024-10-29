using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Core.Dtos
{
    public class AddPostDto
    {
        [Required]
        public string? Text { get; set; } = null;

        [Required]
        public string? DoctorPhone { get; set; } = null;

        [AllowNull]
        public IFormFile? image { get; set; }

        [AllowNull]
        public IFormFile? vedio { get; set; }
    }
}
