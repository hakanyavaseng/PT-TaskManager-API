namespace TaskManager.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = null;
        public bool IsActive { get; set; } = true;
    }
}
