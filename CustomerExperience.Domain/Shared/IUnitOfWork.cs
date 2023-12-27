
namespace CustomerExperience.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}