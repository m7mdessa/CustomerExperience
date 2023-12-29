using CustomerExperience.Domain.CustomerAggregate;


namespace CustomerExperience.Infra.Repositories
{
   
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(AppDbContext context) : base(context) { }
    }
}
