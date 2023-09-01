using BlogApp.Business.Dtos.RoleDtos;
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
        public async Task<IActionResult> Create(RoleCreateDto dto)
        {
            await _roleService.CreateRole(dto);
            return Ok();
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(RoleDeleteDto dto)
        {
            await _roleService.DeleteRole(dto);
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(string oldRoleName,string newRoleName)
        {
            await _roleService.UpdateRole(oldRoleName,newRoleName);
            return Ok();
        }
    }
}
