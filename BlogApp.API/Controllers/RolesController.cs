using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService=roleService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Post(string name)
        {
            await _roleService.CreateAsync(name);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _roleService.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roleService.GetAllAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _roleService.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut]
        public async Task<IActionResult> Put(string id,string name)
        {
            await _roleService.UpdateAsync(id, name);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
