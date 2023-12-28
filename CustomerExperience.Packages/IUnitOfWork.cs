namespace CustomerExperience.Packages
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}