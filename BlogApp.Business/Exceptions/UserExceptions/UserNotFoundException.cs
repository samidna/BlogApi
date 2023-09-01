namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Username or password is wrong") { }

    public UserNotFoundException(string? message) : base(message)
    {
    }
}
