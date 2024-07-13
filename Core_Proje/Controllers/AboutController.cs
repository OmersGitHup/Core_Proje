using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Edit";
            ViewBag.v2 = "About";
            ViewBag.v3 = "AboutPage";
            var values = _aboutManager.TGetByID(3);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {

            _aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");

        }
    }
}
