using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories.Duty;
using TaskManager.Persistence.Contexts;

namespace TaskManager.Persistence.Repositories.Duty
{
    public class DutyWriteRepository : WriteRepository<Domain.Entities.Duty>, IDutyWriteRepository
    {
        public DutyWriteRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
