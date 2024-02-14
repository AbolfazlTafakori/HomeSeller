using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSeller.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [Display(Name = "عنوان")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        #region Relation
        [ForeignKey(nameof(CategoryId))]
        public CategoryModel Category { get; set; }
        #endregion
    }
}

