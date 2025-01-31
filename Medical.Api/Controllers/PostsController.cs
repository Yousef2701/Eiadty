using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IPostRepository _postsRepository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postsRepository,
                               IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        #endregion


        #region Create New Post

        [HttpPost("CreateNewPost")]
        public async Task<IActionResult> CreateNewPost([FromForm] AddPostDto dto)
        {
            return Ok(await _postsRepository.CreateNewPost(dto));
        }

        #endregion

        #region Get All Posts

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postsRepository.GetAllPosts();
            return Ok(posts);
        }

        #endregion

        #region Get All Doctor Posts

        [HttpGet("GetAllDoctorPosts")]
        public async Task<IActionResult> GetAllDoctorPosts(string phone)
        {
            var posts = await _postsRepository.GetAllDoctorPosts(phone);
            return Ok(posts);
        }

        #endregion

        #region Delete Post

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(string postId)
        {
            return Ok(await _postsRepository.DeletePost(postId));
        }

        #endregion

    }
}
