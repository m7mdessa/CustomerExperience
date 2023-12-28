

namespace CustomerExperience.Packages

{
    public abstract class BaseEntity: ISoftDelete
    {
        public int Id { get; protected set; }

        public bool IsDeleted { get; private set; }

        public DateTime DeletedDate { get; private set; }

        public string? DeletedBy { get; private set; }
    }


}

