using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            ViewBag.v1 = "Portfolio";
            ViewBag.v2 = "Add";
            ViewBag.v3 = "AddNewPortfolio";
            return View();
		}
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations=new PortfolioValidator();
            ValidationResult results=validations.Validate(portfolio);
            if (results.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
               
            }
            return View();
			
            
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Portfolio";
            ViewBag.v2 = "Update";
            ViewBag.v3 = "UpdatePortfolio";
            var values = portfolioManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult results = validationRules.Validate(portfolio);
            if (results.IsValid)
            {

                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();



        }
    }
}
