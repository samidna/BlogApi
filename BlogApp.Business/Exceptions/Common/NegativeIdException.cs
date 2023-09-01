using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Exceptions.Common;

public class NegativeIdException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage {get;}
    public NegativeIdException() : base() 
    {
        ErrorMessage = "Id must not be less than 1";
    }

    public NegativeIdException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

}
