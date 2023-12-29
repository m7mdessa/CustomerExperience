

namespace CustomerExperience.Core.Domain.RoleAggregate
{
    public interface IRoleRepository 
    {
        Task UpdateRoleAsync(Role updaterole);
        Task<Role> CreateRoleAsync(Role createRole);
        Task<Role> GetRole(int id);
    }  
}
