

namespace CustomerExperience.Core.Domain.RoleAggregate
{
    public interface IRoleRepository 
    {
        Task UpdateAsync(Role role);
        Task<Role> AddAsync(Role role);
        Task<Role> GetByIdAsync(int id);
        string Login(string username, string password);

    }
}
