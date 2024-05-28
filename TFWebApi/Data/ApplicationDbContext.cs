using Microsoft.EntityFrameworkCore;
using TFWebApi.Data.Model;

namespace TFWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Lector> lectors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Student>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Student>().Property(x => x.Name).IsRequired();

        //    modelBuilder.Entity<Student>().HasOne(x => x.Lector).WithMany(x => x.Students);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseLazyLoadingProxies();
        //}

    }
}
