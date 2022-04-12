using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetPetRejestration.Models;

namespace VetPetRejestration.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .Property(e => e.Name)
             .HasMaxLength(250);

            modelBuilder.Entity<User>()
               .Property(e => e.LastName)
               .HasMaxLength(250);

     
        }

        public DbSet<Models.Pet> Pets { get; set; }
        public DbSet<Models.MedicalHistory> MedicalHistories { get; set; }
    }
}