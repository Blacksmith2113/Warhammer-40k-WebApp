using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Pages
{
    public class UnitListModel : PageModel {

        private readonly IUnitRepository _unitRepository;

        private readonly Dictionary<string, int> _categoryOrder = new Dictionary<string, int> {
            {"Characters", 1 },
            {"Battleline", 2 },
            {"Dedicated Transport", 3 },
            {"Other Datasheets", 4 },
            {"Allied Units", 5 }
        };

        [BindProperty]
        public List<Unit> Units { get; set; }

        public IEnumerable<Unit> OrderedUnits => Units
            .OrderBy(u => _categoryOrder.GetValueOrDefault(u.Category ?? "Unknown", 99))    //Operator koalescencji Jezeli jest null to "Unknown", jeżeli nie jest to u.Category czyli nazwa kategorii
            .ThenBy(u => u.Name);

        public UnitListModel(IUnitRepository unitRepository) {
            _unitRepository = unitRepository;
        }

        public void OnGet() {
            Units = _unitRepository.ReadAll();
        }
        public IActionResult OnPostDelete(int id) {
            Unit unit = _unitRepository.Read(id);

            _unitRepository.Delete(unit);

            return RedirectToPage();
        }
    }
}
