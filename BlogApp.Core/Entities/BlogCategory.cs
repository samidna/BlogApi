using BlogApp.Core.Entities.Commons;

namespace BlogApp.Core.Entities;

public class BlogCategory : BaseEntity
{
    public int CategoryId { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public Category Category { get; set; }
}
