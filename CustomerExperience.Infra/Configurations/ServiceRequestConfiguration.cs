using CustomerExperience.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CustomerExperience.Infra.Configurations

{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {

        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {


            builder
                .ToTable("ServiceRequests");

            builder
                .HasKey(sr => sr.Id);

            builder
               .HasOne(c => c.Customer)
               .WithMany(sr => sr.ServiceRequests)
               .HasForeignKey(c => c.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
