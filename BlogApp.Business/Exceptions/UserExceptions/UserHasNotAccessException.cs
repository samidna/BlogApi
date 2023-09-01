namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserHasNotAccessException : Exception
{
    public UserHasNotAccessException() : base("User has not access for this command")
    {
    }

    public UserHasNotAccessException(string? message) : base(message)
    {
    }
}
