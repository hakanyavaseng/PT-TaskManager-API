using AutoMapper;
using MediatR;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Commands.UpdateDuty
{
    public class UpdateDutyCommandHandler : IRequestHandler<UpdateDutyCommandRequest, UpdateDutyCommandResponse>
    {
        private readonly IDutyReadRepository readRepository;
        private readonly IDutyWriteRepository writeRepository;
        private readonly IMapper mapper;

        public UpdateDutyCommandHandler(IDutyReadRepository readRepository, IDutyWriteRepository writeRepository, IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateDutyCommandResponse> Handle(UpdateDutyCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Duty? duty = await readRepository.GetByGuidIdAsync(request.Id.ToString(),false);
            if (duty == null)
            {
                throw new ArgumentNullException(nameof(duty));
            }

            var map = mapper.Map<UpdateDutyCommandRequest,Domain.Entities.Duty>(request);
            writeRepository.Update(map);

            if (await writeRepository.SaveAsync() > 0)
                return new UpdateDutyCommandResponse()
                {
                    isSuccessed = true,
                };
            else
                return new UpdateDutyCommandResponse()
                {
                    isSuccessed = false,
                };
            
        }
    }
}
