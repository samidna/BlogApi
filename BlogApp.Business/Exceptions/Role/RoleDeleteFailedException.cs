using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.Role;

public class RoleDeleteFailedException : Exception, IBaseException
{
    public RoleDeleteFailedException()
    {
        ErrorMessage = "Something went wrong";
    }

    public RoleDeleteFailedException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }
}
