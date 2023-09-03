using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.Role;

public class RoleExistException : Exception, IBaseException
{
    public RoleExistException()
    {
        ErrorMessage = "This role already exist";
    }

    public RoleExistException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }
}
