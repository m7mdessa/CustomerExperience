using CustomerExperience.Domain.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  CustomerExperience.Infra.Configurations
{
    public class PostInteractionConfiguration : IEntityTypeConfiguration<PostInteraction>
    {

        public void Configure(EntityTypeBuilder<PostInteraction> builder)
        {


            builder
                .ToTable("PostInteractions");

      
            builder
                .HasKey(pi => pi.Id);

            builder
              .HasOne(p => p.Post)
              .WithMany(pi => pi.PostInteractions)
              .HasForeignKey(p => p.PostId)
              .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
