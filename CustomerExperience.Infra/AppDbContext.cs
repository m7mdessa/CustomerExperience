using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using CustomerExperience.Domain.RoleAggregate;
using CustomerExperience.Infra.Configurations;


namespace CustomerExperience.Infra
{


    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("CX");
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration()); 
            modelBuilder.ApplyConfiguration(new PostInteractionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());




        }

    }
}
