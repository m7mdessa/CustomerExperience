using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;


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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("CX");



        }

    }
}
