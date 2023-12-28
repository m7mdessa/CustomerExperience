using CustomerExperience.Domain.RoleAggregate;

namespace CustomerExperience.Infra.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {

        public RoleRepository(AppDbContext context) : base(context) { }
    }
}
