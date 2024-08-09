using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
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
                ImageURL = userRegisterViewModel.Image

            };
            if (userRegisterViewModel.ConfirmPassword == userRegisterViewModel.Password)
            {
                var result = await _userManager.CreateAsync(w, userRegisterViewModel.Password);




                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard");
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
