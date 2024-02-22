using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TafakoriHomeSeller.Data;
using TafakoriHomeSeller.Models.ViewModels;

namespace TafakoriHomeSeller.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public HeaderComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _db.ApplicationUser
                    .FirstOrDefaultAsync(a => a.UserName == User.Identity.Name);
                HeaderViewModel model = new()
                {
                    FullName = user.FullName
                };
                return View("/Pages/Shared/ViewComponents/_HeaderViewComponent.cshtml",model);

            }
            return View("/Pages/Shared/ViewComponents/_HeaderViewComponent.cshtml", new HeaderViewModel());
        }
    }
}
