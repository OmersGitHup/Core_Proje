using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
	public class ErrorPagesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
