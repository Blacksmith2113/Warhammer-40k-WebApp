using WebApp.Model;

namespace WebApp.Repositories {
    public class UnitRepository : IUnitRepository {
        public static string dbFilePath = Path.Combine(Environment.CurrentDirectory, "dbUnits.db");
        public static string connectionString = $"Data Source = {dbFilePath}";

        private AppDbContext dbContext = new AppDbContext();

        public UnitRepository() {
            dbContext.Database.EnsureCreated();
        }

        public bool Create(Unit e) {
            return true;
        }

        public List<Unit> ReadAll() {
            return new List<Unit>();
        }

        public Unit Read(int id) {
            return new Unit();
        }

        public bool Update(Unit e) {
            return true;
        }
               
        public bool Delete(Unit e) {
            return true;
        }
    }
}
