using CustomerExperience.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CustomerExperience.Infra.Configurations

{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {

        public void Configure(EntityTypeBuilder<Feedback> builder)
        {


            builder
                .ToTable("Feedbacks");

            builder
                .HasKey(fb => fb.Id);

            builder
               .HasOne(c => c.Customer)
               .WithMany(fb => fb.Feedbacks)
               .HasForeignKey(c => c.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
