using AutoMapper;
using BlogApp.Business.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Profiles;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<RoleCreateDto, IdentityRole>().ReverseMap();
        CreateMap<RoleDeleteDto, IdentityRole>().ReverseMap();
        CreateMap<RoleUpdateDto, IdentityRole>().ReverseMap();
    }
}
