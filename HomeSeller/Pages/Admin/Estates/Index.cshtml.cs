using HomeSeller.Data;
using HomeSeller.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeSeller.Pages.Admin.Estates
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<EstateModel> IndexDto { get; set; }
        public async Task<IActionResult> OnGet()
        {
            IndexDto = await _db.Estate.ToListAsync();
            return Page();
        }
    }
}
