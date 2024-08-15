using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
	[Route("Writer/[controller]/[action]")]
	public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {

            WriterUser w = new WriterUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Email,
                UserName = userRegisterViewModel.UserName,
                ImageURL = "/../../../../../../../../ömer faruk/documents/m/yazılım/orta seviye projelerim/core_proje/core_proje/wwwroot/userimage/png_user_picture.png"

			};
            if (userRegisterViewModel.ConfirmPassword == userRegisterViewModel.Password)
            {
                var result = await _userManager.CreateAsync(w, userRegisterViewModel.Password);




                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }

            return View(userRegisterViewModel);
        }
    }
}
