using Microsoft.EntityFrameworkCore;
using WebApp.Repositories;

namespace WebApp.Model {
    public class AppDbContext : DbContext{
        public DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(UnitRepository.connectionString);
        }
    }
}
