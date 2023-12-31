﻿using FluentValidation;

namespace BlogApp.Business.Dtos.BlogDtos;

public record BlogUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? CoverImageUrl { get; set; }
}
public class BlogUpdateDtoValidator : AbstractValidator<BlogUpdateDto>
{
    public BlogUpdateDtoValidator()
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
    }
}
