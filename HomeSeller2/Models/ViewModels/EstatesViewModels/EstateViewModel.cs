using Microsoft.AspNetCore.Mvc.Rendering;

namespace TafakoriHomeSeller.Models.ViewModels.EstatesViewModels
{
    public class EstateViewModel
    {
        public EstateModel? Estate { get; set; }

        #region Upload
        public IFormFile? ImgUp { get; set; }
        #endregion
        #region Category
        public SelectList? CategoryOptions { get; set; }
        public string? SelectedCategory { get; set; }
        #endregion

    }
}
