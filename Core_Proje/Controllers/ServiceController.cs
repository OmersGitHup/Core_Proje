using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Service";
            ViewBag.v2 = "ServiceList";
            ViewBag.v3 = "Service";
            var values = _serviceManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Service service)
        {

            _serviceManager.TUpdate(service);
            return RedirectToAction("Index", "Default");

        }
    }
}
