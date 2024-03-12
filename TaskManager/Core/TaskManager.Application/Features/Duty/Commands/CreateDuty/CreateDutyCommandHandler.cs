using AutoMapper;
using MediatR;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Commands.CreateDuty
{
    public class CreateDutyCommandHandler : IRequestHandler<CreateDutyCommandRequest, CreateDutyCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IDutyWriteRepository repository;

        public CreateDutyCommandHandler(IMapper mapper, IDutyWriteRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<CreateDutyCommandResponse> Handle(CreateDutyCommandRequest request, CancellationToken cancellationToken)
        {

            var map = mapper.Map<Domain.Entities.Duty>(request);
            await repository.AddAsync(map);
            await repository.SaveAsync();

            return new();
        }
    }
}
