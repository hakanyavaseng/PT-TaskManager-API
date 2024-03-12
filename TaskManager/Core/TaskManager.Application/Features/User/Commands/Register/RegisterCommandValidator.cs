using FluentValidation;

namespace TaskManager.Application.Features.User.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .EmailAddress();
        }
    }
}
