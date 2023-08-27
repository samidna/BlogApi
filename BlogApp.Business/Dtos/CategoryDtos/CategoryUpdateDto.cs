using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Dtos.CategoryDtos;

public record CategoryUpdateDto
{
    public string Name { get; set; }
    public IFormFile? Logo { get; set; }
}
public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
                .WithMessage("Category name must not be empty")
            .NotNull()
                .WithMessage("Category name must not be null")
            .MaximumLength(64)
                .WithMessage("Category name must not be more than 64");
    }
}
