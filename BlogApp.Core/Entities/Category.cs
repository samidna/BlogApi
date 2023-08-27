using BlogApp.Core.Entities.Commons;

namespace BlogApp.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string LogoUrl { get; set; }
}

