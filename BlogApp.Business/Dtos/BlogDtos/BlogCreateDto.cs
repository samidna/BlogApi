using FluentValidation;

namespace BlogApp.Business.Dtos.BlogDtos;

public record BlogCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public IEnumerable<int> CategoryIds { get; set; }
}
public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
{
    public BlogCreateDtoValidator()
    {
        RuleFor(b => b.Title)
            .NotNull()
                .WithMessage("Title must not be null")
            .NotEmpty()
                .WithMessage("Title must not be empty")
            .MaximumLength(256)
                .WithMessage("Title length must be less than 256");
        RuleFor(b => b.Description)
            .NotNull()
                .WithMessage("Description must not be null")
            .NotEmpty()
                .WithMessage("Description must not be empty");
        RuleFor(b => b.CoverImageUrl)
            .NotNull()
                .WithMessage("CoverImageUrl must not be null")
            .NotEmpty()
                .WithMessage("CoverImageUrl must not be empty");
        RuleForEach(b => b.CategoryIds)
            .NotEmpty();
        RuleForEach(b => b.CategoryIds)
            .NotEmpty()
            .GreaterThan(0);
    }
}
