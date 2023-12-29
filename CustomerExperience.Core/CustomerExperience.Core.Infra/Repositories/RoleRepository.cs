

using CustomerExperience.Core.Domain.RoleAggregate;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomerExperience.Core.Infra.Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly AppDbContext _dbContext;
        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateRoleAsync(Role updaterole)
        {
            _dbContext.Roles.Update(updaterole);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> CreateRoleAsync(Role createRole)
        {
            _dbContext.Roles.Add(createRole);
            await _dbContext.SaveChangesAsync();
            return createRole;
        }
        public async Task<Role> GetRole(int id)
        {
            return await _dbContext.Roles.Include(r=>r.Users).FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}
