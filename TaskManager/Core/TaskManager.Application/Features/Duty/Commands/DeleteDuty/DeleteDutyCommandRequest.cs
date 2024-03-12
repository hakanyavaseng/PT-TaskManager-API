using MediatR;

namespace TaskManager.Application.Features.Duty.Commands.DeleteDuty
{
    public class DeleteDutyCommandRequest : IRequest<DeleteDutyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}