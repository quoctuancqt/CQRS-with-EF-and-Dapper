namespace Demo
{
    using CQRS.Commons;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class DemoDbContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }

        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(HelperAppSettings.ConnectionString);
        }
    }
}
