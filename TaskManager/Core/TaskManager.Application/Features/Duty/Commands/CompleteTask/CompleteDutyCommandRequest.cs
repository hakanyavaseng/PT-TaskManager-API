using MediatR;

namespace TaskManager.Application.Features.Duty.Commands.CompleteTask
{
    public class CompleteDutyCommandRequest : IRequest<CompleteDutyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
