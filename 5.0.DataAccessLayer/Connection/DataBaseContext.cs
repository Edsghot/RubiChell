using _5._0.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5._0.DataAccessLayer.Connection
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tuser");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NSJU15G\\JHAIR;Initial Catalog = RubiChell2;Trusted_Connection =True;TrustServerCertificate=True;");
        }
    }
}