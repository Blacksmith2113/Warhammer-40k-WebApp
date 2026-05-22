using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;

namespace WebApp.Pages
{
    public class ViewModel : PageModel
    {
        public Unit Unit { get; set; }
        public void OnGet(int id)
        {
            Unit = UnitListModel.Units.FirstOrDefault(u => u.Id == id);
        }
    }
}
