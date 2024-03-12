using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Queries.GetAllDutiesByPaging
{
    public class GetAllDutiesByPagingQueryHandler : IRequestHandler<GetAllDutiesByPagingQueryRequest, IList<GetAllDutiesByPagingQueryResponse>>
    {
        private readonly IDutyReadRepository readRepository;
        private readonly IMapper mapper;

        public GetAllDutiesByPagingQueryHandler(IDutyReadRepository readRepository, IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllDutiesByPagingQueryResponse>> Handle(GetAllDutiesByPagingQueryRequest request, CancellationToken cancellationToken)
        {
            var duties = await readRepository.GetAllByPaging(request.PageIndex, request.PageSize, false, request.OrderBy, request.filterTime).ToListAsync();
            var map = mapper.Map<List<GetAllDutiesByPagingQueryResponse>>(duties);

            return map;
        }
    }
}
