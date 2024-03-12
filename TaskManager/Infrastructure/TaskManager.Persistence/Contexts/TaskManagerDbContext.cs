using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Entities.Common;
using TaskManager.Domain.Entities.Identity;

namespace TaskManager.Persistence.Contexts
{
    public class TaskManagerDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {
        }


   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>()
                .HasData(new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedName = "USER",
                });
            base.OnModelCreating(builder);
        }

        public DbSet<Duty> Duties { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entry = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in entry)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
