using TaskManager.Application.Bases;

namespace TaskManager.Application.Features.Duty.Rules
{
    public class DutyRules : BaseRules
    {
        public Task DutyTitleMustNotBeEmpty(Domain.Entities.Duty? duty)
        {
            if(duty == null) throw new ArgumentNullException(nameof(duty));
            return Task.CompletedTask;
        }


    }
}
