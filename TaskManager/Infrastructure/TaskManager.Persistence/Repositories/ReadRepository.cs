using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entities.Common;
using TaskManager.Persistence.Contexts;

namespace TaskManager.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly TaskManagerDbContext _context;

        public ReadRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }



        public async Task<T> GetByGuidIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public virtual IQueryable<T> GetAllByPaging(int page, int pageSize, bool tracking = true, string? orderBy = null, string? filterTime = null)
        {

            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            if (orderBy != null)
                if (orderBy == "asc")
                    query = query.OrderBy(p => p.CreatedDate);
            if (orderBy == "desc")
                query = query.OrderByDescending(p => p.CreatedDate);
            return query;
        }
    }
}
