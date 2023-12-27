using CustomerExperience.Domain.CategoryAggregate;
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

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("CX");



        }

    }
}
