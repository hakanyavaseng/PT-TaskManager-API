using MediatR;

namespace TaskManager.Application.Features.Duty.Queries.GetAllDutiesByPaging
{
    public class GetAllDutiesByPagingQueryRequest : IRequest<IList<GetAllDutiesByPagingQueryResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }

        public string? filterTime { get; set; }
    }
}
