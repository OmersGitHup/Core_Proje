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

		[HttpGet]
		public IActionResult AddService()
		{
			ViewBag.v1 = "Service";
			ViewBag.v2 = "AddService";
			ViewBag.v3 = "Add";
			return View();
		}
		[HttpPost]
		public IActionResult AddService(Service service)
		{
			_serviceManager.TAdd(service);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteService(int id)
		{
			var values = _serviceManager.TGetByID(id);
			_serviceManager.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditService(int id)
		{
			ViewBag.v1 = "Service";
			ViewBag.v2 = "Update";
			ViewBag.v3 = "Service";
			var values = _serviceManager.TGetByID(id);
			return View(values);

		}
		[HttpPost]
		public IActionResult EditService(Service service)
		{

			_serviceManager.TUpdate(service);
			return RedirectToAction("Index");

		}
	}
}
