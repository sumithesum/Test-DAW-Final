using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Profesori> Profesori { get; set; }

        public DbSet<Materii> Materii { get; set; }

        public DbSet<Join> Join { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Join>().HasKey(p => new { p.ProfesorId, p.MaterieId });

            modelBuilder.Entity<Join>().HasOne(p => p.Profesori)
                                               .WithMany(p => p.Join)
                                               .HasForeignKey(p => p.ProfesorId);


            modelBuilder.Entity<Join>().HasOne(p => p.Materie)
                                               .WithMany(p => p.Join)
                                               .HasForeignKey(p => p.MaterieId);




           
        }
    }
}
