using TaskManager.Application.Bases;

namespace TaskManager.Application.Features.Duty.Exceptions
{
    public class DeletingFailedIdNotFoundException : BaseExceptions
    {
      

        public DeletingFailedIdNotFoundException(string? message = "Duty has not been deleted, Id wrong!") : base(message)
        {
          
        }
    }
}
