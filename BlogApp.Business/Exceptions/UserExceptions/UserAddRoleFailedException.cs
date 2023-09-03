using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserAddRoleFailedException : Exception, IBaseException
{
    public UserAddRoleFailedException()
    {
        ErrorMessage = "Something went wrong";
    }

    public UserAddRoleFailedException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }
}
