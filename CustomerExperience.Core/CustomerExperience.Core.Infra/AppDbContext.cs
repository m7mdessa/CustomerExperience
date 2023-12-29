
using CustomerExperience.Core.Domain.RoleAggregate;
using CustomerExperience.Core.Infra.Configurations;
using Microsoft.EntityFrameworkCore;


namespace CustomerExperience.Core.Infra
{


    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("CX");
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
