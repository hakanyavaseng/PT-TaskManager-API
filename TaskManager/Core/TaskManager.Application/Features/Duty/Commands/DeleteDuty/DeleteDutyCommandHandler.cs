using MediatR;
using TaskManager.Application.Features.Duty.Exceptions;
using TaskManager.Application.Interfaces.Repositories.Duty;

namespace TaskManager.Application.Features.Duty.Commands.DeleteDuty
{
    public class DeleteDutyCommandHandler : IRequestHandler<DeleteDutyCommandRequest, DeleteDutyCommandResponse>
    {
        private readonly IDutyWriteRepository writeRepository;
        private readonly IDutyReadRepository readRepository;

        public DeleteDutyCommandHandler(IDutyWriteRepository writeRepository, IDutyReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<DeleteDutyCommandResponse> Handle(DeleteDutyCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Duty? duty = await readRepository.GetSingleAsync(p => p.Id == request.Id);
            if (duty is null)
                throw new DeletingFailedIdNotFoundException();

            await writeRepository.RemoveAsync(request.Id.ToString());

            if (await writeRepository.SaveAsync() > 0)
                return new DeleteDutyCommandResponse() { IsSuccessed = true };
            else
                return new DeleteDutyCommandResponse() { IsSuccessed = false };



        }
    }
}
