using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HomeSeller.Models.ViewModel
{
    public class EstateModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [Display(Name ="عنوان")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [Display(Name = "متراژ")]
        public int Metrage { get; set; }
        public string Image  { get; set; }
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [Display(Name = "قیمت")]
        public double price { get; set; }
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [Display(Name = "ادرس")]
        [MaxLength(600)]
        public string Address { get; set; }

    }
}
