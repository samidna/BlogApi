using FluentValidation;
using System.Text.RegularExpressions;

namespace BlogApp.Business.Dtos.UserDtos;

public record RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
                .WithMessage("Name must not be null")
            .NotEmpty()
                .WithMessage("Name must not be empty")
            .MinimumLength(2)
                .WithMessage("Name length must be more than 2")
            .MaximumLength(25)
                .WithMessage("Name length must be less than 25");
        RuleFor(c => c.Surname)
            .NotNull()
                .WithMessage("Surname must not be null")
            .NotEmpty()
                .WithMessage("Surname must not be empty")
            .MinimumLength(2)
                .WithMessage("Surname length must be more than 2")
            .MaximumLength(25)
                .WithMessage("Surname length must be less than 25");
        RuleFor(c => c.Email)
            .NotNull()
                .WithMessage("Email must not be null")
            .NotEmpty()
                .WithMessage("Email must not be empty")
            .Must(c =>
            {
                Regex reg = new(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                var result = reg.Match(c);
                return result.Success;
            })
                .WithMessage("Please enter valid email");
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
        RuleFor(c => c)
            .NotNull()
                .WithMessage("ConfirmPassword must not be null")
            .NotEmpty()
                .WithMessage("ConfirmPassword must not be empty")
            .Must(c => c.Password == c.ConfirmPassword)
                .WithMessage("Password and ConfirmPassword must be same");












    }
}
