using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Business.ExternalServices.Implements;

public class TokenService : ITokenService
{
    readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config=config;
    }

    public TokenResponseDto CreateToken(AppUser user, int expires = 60)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.Name),
            new Claim(ClaimTypes.Surname, user.Surname),
        };
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwtSecurityToken = new(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(30),
            signingCredentials
            );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(jwtSecurityToken);
        return new()
        {
            Token = token,
            Expires = jwtSecurityToken.ValidTo,
            UserName = user.UserName
        };
    }
}
