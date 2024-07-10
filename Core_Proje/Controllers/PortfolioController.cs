using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
	public class PortfolioController : Controller
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
		public IActionResult Index()
		{
            ViewBag.v1 = "Portfolio";
            ViewBag.v2 = "Index";
            ViewBag.v3 = "List";
            var values = portfolioManager.TGetList();

			return View(values);
		}
		[HttpGet]
		public IActionResult AddPortfolio()
		{
			return View();
		}
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
			portfolioManager.TAdd(portfolio);
			return RedirectToAction();
            
        }
    }
}
