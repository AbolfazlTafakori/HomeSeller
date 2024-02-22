using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TafakoriHomeSeller.Data;
using TafakoriHomeSeller.Models;
using TafakoriHomeSeller.Models.ViewModels.EstatesViewModels;

namespace TafakoriHomeSeller.Pages.Panel.Admin.Estates
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public EstateModel ViewModel { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }
            ViewModel = await _db.Estate
                .Include(c=>c.Category)
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (ViewModel is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
