using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories.Duty;
using TaskManager.Persistence.Contexts;

namespace TaskManager.Persistence.Repositories.Duty
{
    public class DutyReadRepository : ReadRepository<Domain.Entities.Duty>, IDutyReadRepository
    {
        public DutyReadRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

       
        public override IQueryable<Domain.Entities.Duty> GetAllByPaging(int page, int pageSize, bool tracking = true, string? orderBy = null, string? filterTime=null)
        {
            var query = Table.AsQueryable();

            if (filterTime != null)
            {
                var selectedDeadlineFilter = filterTime switch
                {
                    "w" => DateTime.UtcNow.AddDays(7),
                    "m" => DateTime.UtcNow.AddMonths(1),
                    "y" => DateTime.UtcNow.AddYears(1),
                    _ => DateTime.UtcNow
                };

                query = query.Where(p => p.Deadline <= selectedDeadlineFilter);
            }

            if (!tracking)
                query = query.AsNoTracking();

            if (orderBy != null)
            {
                if (orderBy == "asc")
                    query = query.OrderBy(p => p.Deadline);
                else if (orderBy == "desc")
                    query = query.OrderByDescending(p => p.Deadline);
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
