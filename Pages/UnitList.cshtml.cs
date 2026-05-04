using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class UnitListModel : PageModel {
        Dictionary<string, int> _categoryOrder = new Dictionary<string, int> {
            {"Characters", 1 },
            {"Battleline", 2 },
            {"Dedicated Transport", 3 },
            {"Other Datasheets", 4 },
            {"Allied Units", 5 }
        };
        List<Unit> _units = new List<Unit>();
        IEnumerable<string> _sortedCategories => _units
            .Select(u => u.Category)
            .Distinct()
            .OrderBy(c => _categoryOrder.GetValueOrDefault(c, 99));
        
        public void OnGet() {
            _units.Add(new Unit {
                Name = "Eightbound",
                Points = 135,
                Image = "/Images/Eightbound.jpg",
                Category = "Other Datasheets"
            });

            _units.Add(new Unit {
                Name = "Angron",
                Points = 365,
                Image = "/Images/Angron.jpg",
                Category = "Characters"
            });

            _units.Add(new Unit {
                Name = "Chaos Rhino",
                Points = 85,
                Image = "/Images/Rhino.jpg",
                Category = "Dedicated Transport"
            });

            _units.Add(new Unit {
                Name = "Khorne Berzerkers",
                Points = 180,
                Image = "/Images/Berzerkers.jpg",
                Category = "Battleline"
            });
        }
    }
}
