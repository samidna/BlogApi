using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Core.Enums;

namespace BlogApp.Business.Dtos.BlogLikeDtos;

public record BlogLikeDetailDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public AuthorDto AppUser { get; set; }
    public Reactions Reaction { get; set; }
}
