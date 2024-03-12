using TaskManager.Application.Bases;

namespace TaskManager.Application.Features.Duty.Exceptions
{
    public class CompletingDutyFailedException : BaseExceptions
    {
        public CompletingDutyFailedException(string? message= "Duty couldn't be marked as completed, duty not found!") : base(message)
        {
        }
    }
}
