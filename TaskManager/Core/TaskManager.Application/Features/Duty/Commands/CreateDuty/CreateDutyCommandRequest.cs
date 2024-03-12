using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Domain.Entities.Identity;
namespace TaskManager.Application.Features.Duty.Commands.CreateDuty
{
    public class CreateDutyCommandRequest : IRequest<CreateDutyCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid AppUserId { get; set; }
    }
}