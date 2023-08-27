using BlogApp.Business.Dtos.UserDtos;

namespace BlogApp.Business.Services.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterDto dto);
}
