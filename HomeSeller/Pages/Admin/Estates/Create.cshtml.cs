using HomeSeller.Data;
using HomeSeller.Models;
using HomeSeller.Models.ViewModel.EstatesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

namespace HomeSeller.Pages.Admin.Estates
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public CreateEstatesViewModel EstateViewModel { get; set; }
        public void OnGet()
        {
            InitCategories();
        }
        private void InitCategories()
        {
            EstateViewModel = new()
            {
                CategoryOption = new SelectList(_db.Category, nameof(CategoryModel.Id), nameof(CategoryModel.Title))
            };
        }
        public async Task<IActionResult> OnPost()
        {
            #region Validation
            if (!ModelState.IsValid || string.IsNullOrEmpty(EstateViewModel.SelectedCategory))
            {
                InitCategories();
                return Page();
            }
            var check = int.TryParse(EstateViewModel.SelectedCategory, out int categoryId);
            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده معتبر نمیباشد");
                InitCategories();
                return Page();
            }
            var category = await _db.Category.FindAsync(categoryId);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده معتبر نمیباشد");
                InitCategories();
                return Page();
            }
            #endregion
            #region Upload image
            if (EstateViewModel.ImgUp is not null)
            {
                string saveDir = "wwwroot/image/Estates";
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                EstateViewModel.Estates.Image = Guid.NewGuid().ToString() + Path.GetExtension(EstateViewModel.ImgUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, EstateViewModel.Estates.Image);
                using (var filestream = new FileStream(savepath, FileMode.Create))
                {
                    EstateViewModel.ImgUp.CopyTo(filestream);
                }
            }
            #endregion

            EstateViewModel.Estates.CategoryId = categoryId;
            await _db.Estate.AddAsync(EstateViewModel.Estates);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
