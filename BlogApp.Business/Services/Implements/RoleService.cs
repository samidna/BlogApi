using AutoMapper;
using BlogApp.Business.Dtos.RoleDtos;
using BlogApp.Business.Exceptions.RoleExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Business.Services.Implements;

public class RoleService : IRoleService
{
    readonly AppDbContext _context;
    readonly RoleManager<IdentityRole> _roleManager;
    readonly IMapper _mapper;
    public RoleService(RoleManager<IdentityRole> roleManager, IMapper mapper, AppDbContext context)
    {
        _roleManager = roleManager;
        _mapper=mapper;
        _context=context;
    }

    public async Task CreateRole(RoleCreateDto dto)
    {
        IdentityRole identityRole = new()
        {
            Name=dto.Name
        };
        await _roleManager.CreateAsync(identityRole);
    }

    public async Task DeleteRole(RoleDeleteDto dto)
    {
        var entity = await _roleManager.Roles.SingleOrDefaultAsync(c => c.Name == dto.Name);
        if (entity == null) throw new RoleNotFoundException();
        await _roleManager.DeleteAsync(entity);
    }

    public async Task UpdateRole(string oldRoleName, string newRoleName)
    {
        var entity = _roleManager.Roles.SingleOrDefault(c => c.Name == oldRoleName);
        if (entity == null) throw new RoleNotFoundException();
        entity.Name = newRoleName;
        await _context.SaveChangesAsync();
    }
}
