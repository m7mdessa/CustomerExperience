using CustomerExperience.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  CustomerExperience.Infra.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {


            builder
                .ToTable("Roles");

      
            builder
                .HasKey(r => r.Id);

         

        }
    }
}
