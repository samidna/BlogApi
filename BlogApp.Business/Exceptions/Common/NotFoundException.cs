using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.Common;

public class NotFoundException<T> : Exception, IBaseException where T : class
{
    public NotFoundException() : base()
    {
        ErrorMessage = typeof(T).Name + "not found";
    }

    public NotFoundException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public int StatusCode => StatusCodes.Status404NotFound;

    public string ErrorMessage { get; }
}
