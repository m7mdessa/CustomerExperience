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

        //public DbSet<Project> Projects { get; set; }

        //public DbSet<Developer> Developers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("CX");



        }

    }
}
