using MediatR;
using TaskManager.Application.Features.Duty.Exceptions;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Commands.CompleteTask
{
    public class CompleteDutyCommandHandler : IRequestHandler<CompleteDutyCommandRequest, CompleteDutyCommandResponse>
    {
        private readonly IDutyWriteRepository writeRepository;
        private readonly IDutyReadRepository readRepository;

        public CompleteDutyCommandHandler(IDutyWriteRepository writeRepository, IDutyReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<CompleteDutyCommandResponse> Handle(CompleteDutyCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Duty? duty = await readRepository.GetByGuidIdAsync(request.Id.ToString());
            if (duty == null)
                throw new CompletingDutyFailedException();

            duty.IsActive = false;
            if (await writeRepository.SaveAsync() > 0)
                return new CompleteDutyCommandResponse() { IsSuccessed = true };
            return new CompleteDutyCommandResponse() { IsSuccessed = false };


        }
    }
}
