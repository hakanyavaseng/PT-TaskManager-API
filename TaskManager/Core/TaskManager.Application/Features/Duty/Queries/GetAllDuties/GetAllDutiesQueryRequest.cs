using MediatR;

namespace TaskManager.Application.Features.Duty.Queries.GetAllDuties
{
    public class GetAllDutiesQueryRequest : IRequest<IList<GetAllDutiesQueryResponse>>
    {
        public Guid Id { get; set; }

    }
}
