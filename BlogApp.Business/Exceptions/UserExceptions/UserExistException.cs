namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserExistException : Exception
{
    public UserExistException() : base("User not found")
    {
    }

    public UserExistException(string? message) : base(message)
    {
    }
}
