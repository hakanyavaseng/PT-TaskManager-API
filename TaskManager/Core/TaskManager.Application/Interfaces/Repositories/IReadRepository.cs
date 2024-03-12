using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TaskManager.Domain.Entities.Common;


namespace TaskManager.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //In IQueryable, the data is not retrieved from the database until the data is requested. However, when we use IEnumerable, the data is retrieved from the database immediately and processed in memory.
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetAllByPaging(int page, int pageSize,  bool tracking = true, string? orderBy = null, string? filterTime=null);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByGuidIdAsync(string id, bool tracking = true);


    }
}
