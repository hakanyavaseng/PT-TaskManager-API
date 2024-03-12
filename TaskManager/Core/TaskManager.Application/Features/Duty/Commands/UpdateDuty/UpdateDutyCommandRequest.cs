using MediatR;

namespace TaskManager.Application.Features.Duty.Commands.UpdateDuty
{
    public class UpdateDutyCommandRequest : IRequest<UpdateDutyCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}