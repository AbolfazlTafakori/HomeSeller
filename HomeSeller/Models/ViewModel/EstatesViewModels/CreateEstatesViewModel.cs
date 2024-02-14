using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeSeller.Models.ViewModel.EstatesViewModels
{
    public class CreateEstatesViewModel
    {
        public EstateModel? Estates { get; set; }

        #region Uploade
        public IFormFile? ImgUp { get; set; }
        #endregion

        #region Category
        public SelectList? CategoryOption { get; set; }
        public string? SelectedCategory { get; set; }
        #endregion
    }
}
