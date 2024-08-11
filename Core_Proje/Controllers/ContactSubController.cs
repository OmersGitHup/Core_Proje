using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactSubController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactManager.TGetByID(2);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {

            _contactManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");

        }

    }
}
