namespace BlogApp.Business.Exceptions.Common;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException() : base("Category not found") { }

    public CategoryNotFoundException(string? message) : base(message)
    {
    }
}
