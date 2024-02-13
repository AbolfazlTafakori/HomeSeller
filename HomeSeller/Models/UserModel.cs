using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeSeller.Models
{
    public class UserModel : IdentityUser
    {
        [Required(ErrorMessage = "لطفا نام کامل خود را وارد کنید")]
        [MaxLength (100, ErrorMessage = "نام شما نمیتواند بیشتر از 100 کاراکتر باشد")]
        public string FullName { get; set; }
    }
}
