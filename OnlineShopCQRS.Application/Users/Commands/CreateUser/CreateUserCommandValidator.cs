
using FluentValidation;

namespace OnlineShopCQRS.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(v => v.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(v => v.IsAdmin)
                .NotNull().WithMessage("IsAdmin field is required.");

            RuleFor(v => v.RecoveryCode)
                .GreaterThan(0).When(v => v.RecoveryCode.HasValue).WithMessage("Recovery code must be greater than zero.");
        }
    }
}
