namespace BlogApp.Business.Exceptions.RoleExceptions;

public class RoleNotFoundException : Exception
{
    public RoleNotFoundException() : base("Role not found")
    {
    }

    public RoleNotFoundException(string? message) : base(message)
    {
    }
}
