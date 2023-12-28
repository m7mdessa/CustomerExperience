namespace CustomerExperience.Packages

{
    public interface IFullAuditedObject
    {
         DateTime CreatedDate { get; }

         string CreatedBy { get; } 


         DateTime ModifiedDate { get; }

         string? ModifiedBy { get; }
    }
}
