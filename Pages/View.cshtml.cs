using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IUnitRepository _unitRepository;
        public ViewModel(IUnitRepository unitRepository) {
            _unitRepository = unitRepository;
        }
        [BindProperty]
        public Unit Unit { get; set; }
        public void OnGet(int id)
        {
            Unit = _unitRepository.Read(id);
        }
    }
}
