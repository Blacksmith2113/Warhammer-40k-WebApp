using System.Numerics;
using WebApp.Model;

namespace WebApp.Repositories {
    public interface IUnitRepository {
        bool Create(Unit e);
        // ReadAll
        List<Unit> ReadAll();
        // Read
        Unit Read(int id);
        // Update
        bool Update(Unit e);
        // Delete
        bool Delete(Unit e);
    }
}
