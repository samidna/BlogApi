using BlogApp.Business.Dtos.RoleDtos;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IRoleService
    {
        Task CreateRole(RoleCreateDto dto);
        Task UpdateRole(string oldRoleName,string newRoleName);
        Task DeleteRole(RoleDeleteDto dto);
    }
}
