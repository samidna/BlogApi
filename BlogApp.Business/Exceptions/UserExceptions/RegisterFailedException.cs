namespace BlogApp.Business.Exceptions.UserExceptions;

public class RegisterFailedException : Exception
{
    public RegisterFailedException() : base("Register failed") { }
    public RegisterFailedException(string? message) : base(message)
    {
    }
}
