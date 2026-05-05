using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class UnitListModel : PageModel {
        private readonly Dictionary<string, int> _categoryOrder = new Dictionary<string, int> {
            {"Characters", 1 },
            {"Battleline", 2 },
            {"Dedicated Transport", 3 },
            {"Other Datasheets", 4 },
            {"Allied Units", 5 }
        };
        public List<Unit> Units = new List<Unit>();
        public IEnumerable<string> SortedCategories => Units
            .Select(u => u.Category)
            .Where(c => c != null)
            .Cast<string>()
            .Distinct()
            .OrderBy(c => _categoryOrder.GetValueOrDefault(c, 99));

        public IEnumerable<Unit> OrderedUnits => Units
            .OrderBy(u => _categoryOrder.GetValueOrDefault(u.Category ?? "Unknown", 99))    //Operator koalescencji Jezeli jest null to "Unknown", jeżeli nie jest to u.Category czyli nazwa kategorii
            .ThenBy(u => u.Name);

        public void OnGet() {
            Units.Add(new Unit {
                Id = 4,
                Name = "Eightbound",
                Points = 135,
                Image = "/Images/Eightbound.jpg",
                Category = "Other Datasheets"
            });

            Units.Add(new Unit {
                Id = 1,
                Name = "Angron",
                Points = 365,
                Image = "/Images/Angron.jpg",
                Category = "Characters"
            });

            Units.Add(new Unit {
                Id = 3,
                Name = "Chaos Rhino",
                Points = 85,
                Image = "/Images/Rhino.jpg",
                Category = "Dedicated Transport"
            });

            Units.Add(new Unit {
                Id = 2,
                Name = "Khorne Berzerkers",
                Points = 180,
                Image = "/Images/Berzerkers.jpg",
                Category = "Battleline"
            });
        }
    }
}
