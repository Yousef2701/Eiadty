using Medical.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public LikesController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost("PostLikes")]
        public async Task<IActionResult> PostLikes(string postId, string patientPhone)
        {
            return Ok(await _postRepository.PostLike(postId, patientPhone));
        }

        [HttpGet("IfUserAddLike")]
        public async Task<IActionResult> IfUserAddLike(string postId, string patientPhone)
        {
            return Ok(await _postRepository.IfUserAddLike(postId, patientPhone));
        }
    }
}
