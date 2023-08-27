using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Dtos.CategoryDtos;

public record CategoryCreateDto
{
    public string Name { get; set; }
    public IFormFile Logo { get; set; }
}
public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
                .WithMessage("Category name must not be empty")
            .NotNull()
                .WithMessage("Category name must not be null")
            .MaximumLength(64)
                .WithMessage("Category name must not be more than 64");
        RuleFor(c => c.Logo)
            .NotEmpty()
                .WithMessage("Category logo must be not null");
    }
}





