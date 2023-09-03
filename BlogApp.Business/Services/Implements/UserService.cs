using AutoMapper;
using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions.Role;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace BlogApp.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userm;
    readonly IMapper _mapper;
    readonly ITokenService _tokenService;
    readonly RoleManager<IdentityRole> _roleManager;


    public UserService(UserManager<AppUser> userm, IMapper mapper, IConfiguration config, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
    {
        _userm=userm;
        _mapper=mapper;
        _tokenService=tokenService;
        _roleManager=roleManager;
    }

    public async Task AddRole(string roleName, string userName)
    {
        var user = await _userm.FindByNameAsync(userName);
        if (user == null) throw new NotFoundException<AppUser>();
        if (!await _roleManager.RoleExistsAsync(roleName)) throw new NotFoundException<IdentityRole>();
        var result = await _userm.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            string a = "";
            foreach (var errors in result.Errors)
            {
                a += errors.Description + " ";
            }
            throw new UserAddRoleFailedException(a);
        }
    }

    public async Task<ICollection<UserWithRoles>> GetAllAsync()
    {
        ICollection<UserWithRoles> users = new List<UserWithRoles>();
        foreach (var user in await _userm.Users.ToListAsync())
        {
            users.Add(new UserWithRoles
            {
                AppUser = _mapper.Map<AuthorDto>(user),
                Roles = await _userm.GetRolesAsync(user)
            });
        }
        return users;
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userm.FindByNameAsync(loginDto.UserName); 
        if(user == null) throw new UserNotFoundException();
        var result = await _userm.CheckPasswordAsync(user, loginDto.Password);
        if (!result) throw new UserNotFoundException();
        return _tokenService.CreateToken(user);
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var user = _mapper.Map<AppUser>(dto);
        if (await _userm.Users.AnyAsync(u => u.UserName == dto.UserName || u.Email == dto.Email))
        {
            throw new UserAlreadyExistException();
        }
        var result = await _userm.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new RegisterFailedException(sb.ToString().TrimEnd());
        }
    }

    public Task RemoveRole(string roleId, string userName)
    {
        throw new NotImplementedException();
    }
}




