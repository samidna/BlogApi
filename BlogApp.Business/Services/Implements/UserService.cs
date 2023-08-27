using AutoMapper;
using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BlogApp.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userm;
    readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userm, IMapper mapper)
    {
        _userm=userm;
        _mapper=mapper;
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
}




