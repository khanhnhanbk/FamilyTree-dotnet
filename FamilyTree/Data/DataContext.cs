using FamilyTree.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<People> Peoples { get; set; }
    }
}
