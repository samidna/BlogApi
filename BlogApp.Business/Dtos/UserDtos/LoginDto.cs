using FluentValidation;

namespace BlogApp.Business.Dtos.UserDtos;

public record LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(c => c.UserName)
          .NotNull()
              .WithMessage("Username must not be null")
          .NotEmpty()
              .WithMessage("Username must not be empty")
          .MinimumLength(3)
              .WithMessage("Username length must be more than 3")
          .MaximumLength(30)
              .WithMessage("Username length must be less than 30");
        RuleFor(c => c.Password)
            .NotNull()
                .WithMessage("Password must not be null")
            .NotEmpty()
                .WithMessage("Password must not be empty")
            .MinimumLength(6)
                .WithMessage("Password length must be more than 6");
    }
}
