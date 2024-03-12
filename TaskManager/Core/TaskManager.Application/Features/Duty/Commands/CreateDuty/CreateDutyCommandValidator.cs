using FluentValidation;

namespace TaskManager.Application.Features.Duty.Commands.CreateDuty
{
    public class CreateDutyCommandValidator : AbstractValidator<CreateDutyCommandRequest>
    {
        public CreateDutyCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(p => p.Description)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(500);

            RuleFor(p => p.Deadline)
                .Must(p => p >= DateTime.UtcNow.AddHours(3));

        }
    }
}
