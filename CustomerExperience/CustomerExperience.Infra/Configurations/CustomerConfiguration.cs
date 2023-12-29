using CustomerExperience.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  CustomerExperience.Infra.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {


            builder
                .ToTable("Customers");

            builder
                .OwnsOne(c => c.Address);
            builder
                .HasKey(c => c.Id);

         

        }
    }
}
