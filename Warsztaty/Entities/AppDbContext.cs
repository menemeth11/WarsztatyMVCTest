using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warsztaty.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<WarsztatEntity> Warsztaty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WarsztatyMVC;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
