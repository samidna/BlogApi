using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Dtos.CommentDtos;

public record CommentListItemDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public AuthorDto AppUser { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<CommentChildDto> Children { get; set; }

}
