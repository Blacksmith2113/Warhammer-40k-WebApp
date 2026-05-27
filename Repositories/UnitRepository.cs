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
            bool isCreated = false;
            dbContext.Units.Add(e);
            if(dbContext.SaveChanges() == 1) {
                isCreated = true;
            }
            return isCreated;
        }

        public List<Unit> ReadAll() {
            return dbContext.Units.ToList();
        }

        public Unit Read(int id) {
            return dbContext.Units.Find(id) ?? new Unit();
        }

        public bool Update(Unit e) {
            bool isUpdated = false;
            var existing = dbContext.Units.Find(e.Id);
            if (existing != null) {
                existing.Name = e.Name;
                existing.Points = e.Points;
                existing.Image = e.Image;
                existing.Category = e.Category;
                existing.Rules = e.Rules;
                if (dbContext.SaveChanges() >= 1) {
                    isUpdated = true;
                }
            }
            return isUpdated;
        }
               
        public bool Delete(Unit e) {
            bool isDeleted = false;
            dbContext.Units.Remove(e);
            if(dbContext.SaveChanges() == 1) {
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
