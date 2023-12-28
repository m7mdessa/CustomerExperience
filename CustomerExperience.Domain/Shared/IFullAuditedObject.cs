namespace CustomerExperience.Domain.Shared
{
    public interface IFullAuditedObject
    {
         DateTime CreatedDate { get; }

         string CreatedBy { get; } 


         DateTime ModifiedDate { get; }

         string? ModifiedBy { get; }
    }
}
