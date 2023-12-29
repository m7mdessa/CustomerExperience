using CustomerExperience.Domain.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  CustomerExperience.Infra.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {


            builder
                .ToTable("Posts");

      
            builder
                .HasKey(p => p.Id);

         

        }
    }
}
