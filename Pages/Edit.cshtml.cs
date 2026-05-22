using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repositories;
using Microsoft.AspNetCore.Components.Web.Virtualization;


namespace WebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly IUnitRepository _unitRepository;

        public EditModel(IUnitRepository unitRepository) {
            _unitRepository = unitRepository;
        }

        [BindProperty]
        public Unit Unit { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet(int id)
        {
            Unit = _unitRepository.Read(id);
        }
    }
}
