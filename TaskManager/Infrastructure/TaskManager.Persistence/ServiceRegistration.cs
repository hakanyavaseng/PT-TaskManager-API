using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces.Repositories.Duty;
using TaskManager.Domain.Entities.Identity;
using TaskManager.Persistence.Contexts;
using TaskManager.Persistence.Repositories.Duty;

namespace TaskManager.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region AddDbContext to IoC Container
            services.AddDbContext<TaskManagerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });
            #endregion

            #region Add Repositories
            //services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            services.AddScoped<IDutyReadRepository, DutyReadRepository>();
            services.AddScoped<IDutyWriteRepository, DutyWriteRepository>();
            #endregion

            #region Add Identity
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<TaskManagerDbContext>();
            #endregion

        }
    }
}
