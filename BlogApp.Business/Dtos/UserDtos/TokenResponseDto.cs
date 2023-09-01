﻿namespace BlogApp.Business.Dtos.UserDtos;

public record TokenResponseDto
{
    public string Token { get; set; }
    public string UserName { get; set; }
    public DateTime Expires { get; set; }
}
