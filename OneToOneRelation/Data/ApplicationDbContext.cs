using Microsoft.EntityFrameworkCore;
using OneToOneRelation.Data.Entities;

namespace OneToOneRelation.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Car> Cars{ get; set; }
        public DbSet<CarRegistration> CarRegistrations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Registration)                   // Car has one Registration
                .WithOne(r => r.Car)                           // CarRegistration has one Car
                .HasForeignKey<CarRegistration>(r => r.CarId); // FK in CarRegistration

            // Make FK unique to enforce one-to-one
            modelBuilder.Entity<CarRegistration>()
                .HasIndex(r => r.CarId)
                .IsUnique();
        }
    }
}
