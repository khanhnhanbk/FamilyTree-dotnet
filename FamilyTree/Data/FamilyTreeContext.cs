using FamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Data
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Father)
                .WithMany()
                .HasForeignKey(p => p.FatherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Mother)
                .WithMany()
                .HasForeignKey(p => p.MotherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Spouse)
                .WithMany()
                .HasForeignKey(p => p.SpouseId)
                .OnDelete(DeleteBehavior.Restrict);
        
    }
    }

}
