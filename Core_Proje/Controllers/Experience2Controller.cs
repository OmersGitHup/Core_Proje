using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ListExperience()
		{
			var values = JsonConvert.SerializeObject(experienceManager.TGetList());
			return Json(values);
		}
		public IActionResult AddExperience(Experience p)
		{
			experienceManager.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}
	}
}
