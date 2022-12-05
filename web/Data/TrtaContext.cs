using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class TrtaContext : IdentityDbContext<ApplicationUser>
    {
        public TrtaContext(DbContextOptions<TrtaContext> options) : base(options)
        {
        }

        //public DbSet<Users> Users { get; set; }
        public DbSet<Trte> Trte { get; set; }
        public DbSet<Pridelek> Pridelek { get; set; }
        public DbSet<Vinogradi> Vinogradi { get; set; }
        public DbSet<Odkup> Odkup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Users>().ToTable("User");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trte>().ToTable("Trte");
            modelBuilder.Entity<Pridelek>().ToTable("Pridelek");
            modelBuilder.Entity<Vinogradi>().ToTable("Vinogradi");
            modelBuilder.Entity<Odkup>().ToTable("Odkup");
        } 
    }
}