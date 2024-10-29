﻿using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly IBaseRepository<Comment> _commentsRepository;
        private readonly IPostRepository _postsRepository;
        private readonly IMapper _mapper;

        public CommentsController(IBaseRepository<Comment> commentsRepository,
                                  IPostRepository postsRepository,
                                  IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewComment")]
        public async Task<IActionResult> CreateNewComment([FromBody] CommentDto dto)
        {
            return Ok(await _commentsRepository.CreateAsync(_mapper.Map<Comment>(dto)));
        }

        [HttpGet("GetPostComments")]
        public async Task<IActionResult> GetPostComments(string postId)
        {
            return Ok(await _postsRepository.GetPostComments(postId));
        }

        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(string postId, int commentNumbre)
        {
            return Ok(await _postsRepository.DeletePostComment(postId, commentNumbre));
        }

    }
}
