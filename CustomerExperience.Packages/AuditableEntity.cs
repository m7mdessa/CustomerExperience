

namespace CustomerExperience.Packages
{
    public abstract class AuditableEntity: BaseEntity, IFullAuditedObject
    {
        public DateTime CreatedDate { get; private set; }

        public string CreatedBy { get; private set; } = string.Empty;

        public DateTime ModifiedDate { get; private set; }

        public string? ModifiedBy { get; private set; }

      
    }
}
