using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Dtos.UserDtos;

public record UserWithRoles
{
    public AuthorDto AppUser { get; set; }
    public ICollection<string> Roles { get; set; }
}
