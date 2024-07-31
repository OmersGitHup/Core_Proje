using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Plese enter username!")]
        public string UserName { get; set; }



        [Display(Name = "Password")]
        [Required(ErrorMessage = "Plese enter password!")]
        public string Password { get; set; }
    }
}
