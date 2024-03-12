using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Queries.GetAllDuties
{
    public class GetAllDutiesQueryHandler : IRequestHandler<GetAllDutiesQueryRequest, IList<GetAllDutiesQueryResponse>>
    {
        private readonly IDutyReadRepository _dutyReadRepository;
        private readonly IMapper mapper;

        public GetAllDutiesQueryHandler(IDutyReadRepository dutyReadRepository, IMapper mapper)
        {
            _dutyReadRepository = dutyReadRepository;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllDutiesQueryResponse>> Handle(GetAllDutiesQueryRequest request, CancellationToken cancellationToken)
        {
            var duties = await _dutyReadRepository
                .GetAll()
                .Where(p=> p.AppUserId == request.Id)
                .ToListAsync();

            var map = mapper.Map<List<GetAllDutiesQueryResponse>>(duties);
            return map;
        }
    }

}
