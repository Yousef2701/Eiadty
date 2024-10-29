using Medical.Core.Interfaces;
using Medical.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetPostVedio")]
        public async Task<IActionResult> GetPostVedio(string postId)
        {
            string vedioname = _context.PostVedios.Where(m => m.PostId == postId).Select(m => m.Vedio_Url).FirstOrDefault();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "PostVedios", vedioname);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", vedioname);
        }

        [HttpGet("GetPostImage")]
        public async Task<IActionResult> GetPostImage(string postId)
        {
            string imagename = _context.PostImages.Where(m => m.PostId == postId).Select(m => m.Image_Url).FirstOrDefault();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "PostImages", imagename);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", imagename);
        }

        [HttpGet("GetDoctorImage")]
        public async Task<IActionResult> GetDoctorImage(string doctorPhone)
        {
            string imagename = _context.Doctors.Where(m => m.Phone == doctorPhone).Select(m => m.ImageUrl).FirstOrDefault();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "UsersImages", imagename);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", imagename);
        }

    }
}
