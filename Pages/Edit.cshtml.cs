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

        public IActionResult OnPost()
        {
            if (ImageFile is not null)
            {
                using MemoryStream ms = new MemoryStream();
                ImageFile.CopyTo(ms);
                Unit.Image = ms.ToArray();
            }
            else
            { 
                var existing = _unitRepository.Read(Unit.Id);
                Unit.Image = existing.Image;
            }

            if (_unitRepository.Update(Unit))
            {
                return RedirectToPage("/UnitList");
            }
            else
            {
                return Page();
            }
        }
    }
}
