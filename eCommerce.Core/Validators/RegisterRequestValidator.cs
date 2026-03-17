using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        // Password
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        // PersonNAme
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person Name is required")
            .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long.");
        // Gender
        RuleFor(x => x.Gender)
            .NotNull().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
