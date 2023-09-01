using BlogApp.Business.Dtos.BlogDtos;
using BlogApp.Business.Dtos.CommentDtos;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        readonly IBlogService _blogService;
        readonly ICommentService _commentService;

        public BlogsController(IBlogService blogService, ICommentService commentService)
        {
            _blogService=blogService;
            _commentService=commentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _blogService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(BlogCreateDto dto)
        {
            try
            {
                await _blogService.CreateAsync(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _blogService.GetByIdAsync(id));
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(id);
            return Ok();
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Comment(int id,CommentCreateDto dto)
        {
            await _commentService.CreateAsync(id,dto);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
