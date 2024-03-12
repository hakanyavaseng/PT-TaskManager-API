using TaskManager.Domain.Entities.Common;
using TaskManager.Domain.Entities.Identity;

namespace TaskManager.Domain.Entities
{
    public class Duty : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
