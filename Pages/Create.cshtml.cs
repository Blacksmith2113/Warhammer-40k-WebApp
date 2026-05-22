using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Repositories;
using WebApp.Model;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IUnitRepository _unitRepository;

        public CreateModel(IUnitRepository unitRepository) {
            _unitRepository = unitRepository;
        }

        [BindProperty]
        public Unit Unit { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            if(ImageFile is not null) {
                using MemoryStream ms = new MemoryStream();
                ImageFile.CopyTo(ms);
                Unit.Image = ms.ToArray();
            }

            if (_unitRepository.Create(Unit)) {
                return RedirectToPage("/UnitList");
            }
            else {
                return RedirectToPage("/Create");
            }
        }
    }
}
