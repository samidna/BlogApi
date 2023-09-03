using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.Role;

public class RoleUpdateFailedException : Exception, IBaseException
{
    public RoleUpdateFailedException()
    {
        ErrorMessage = "Something went wrong";
    }

    public RoleUpdateFailedException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }
}
