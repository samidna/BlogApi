namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserAlreadyExistException : Exception
{
    public UserAlreadyExistException() : base("Username or email already exist") { }

    public UserAlreadyExistException(string? message) : base(message)
    {
    }
}
