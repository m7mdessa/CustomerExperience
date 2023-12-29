
//using CustomerExperience.Core.Domain.RoleAggregate;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace CustomerExperience.Infra.Configurations

//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {

//        public void Configure(EntityTypeBuilder<User> builder)
//        {


//            builder
//                .ToTable("Users");

//            builder
//                .HasKey(u => u.Id);

//            builder
//               .HasOne(r => r.Role)
//               .WithMany(u => u.Users)
//               .HasForeignKey(r => r.RoleId)
//               .OnDelete(DeleteBehavior.Cascade);


//        }
//    }
//}
