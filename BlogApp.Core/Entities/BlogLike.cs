using BlogApp.Core.Entities.Commons;
using BlogApp.Core.Enums;

namespace BlogApp.Core.Entities;

public class BlogLike : BaseEntity
{
    public string AppUserId { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public AppUser AppUser { get; set; }
    public Reactions Reaction { get; set; }
}
