namespace BlogApp.Business.Exceptions.Common;

public class NegativeIdException : Exception
{
    public NegativeIdException() : base("Id must not be less than 1") { }

    public NegativeIdException(string? message) : base(message)
    {
    }
}
