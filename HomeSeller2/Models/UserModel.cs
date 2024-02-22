using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TafakoriHomeSeller.Models
{
    public class UserModel : IdentityUser
    {
        [Required(ErrorMessage ="لطفا نام کامل خود را وارد کنید")]
        [MaxLength(100,ErrorMessage ="نام کامل شما نمی تواند از 100 کاراکتر بیشتر باشد")]
        public string FullName { get; set; }
    }
}
