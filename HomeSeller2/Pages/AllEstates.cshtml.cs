using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TafakoriHomeSeller.Data;
using TafakoriHomeSeller.Models;

namespace TafakoriHomeSeller.Pages
{
    public class AllEstatesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AllEstatesModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<EstateModel> EstatesViewModel { get; set; }

        public async Task<IActionResult> OnGet()
        {
            EstatesViewModel = await
                _db.Estate
                .ToListAsync();
            return Page();
        }
    }
}
