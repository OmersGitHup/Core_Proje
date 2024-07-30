using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please Fill Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Fill Surname")]
        public string Surname { get; set; }


        [Required(ErrorMessage ="Please Fill UserName")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Fill Password")]
        public string Password { get; set; }  


        [Required(ErrorMessage = "Please Fill ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Passwords are NOT same !")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please Fill Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Fill Image")]
        public string Image { get; set; }

    }
}
