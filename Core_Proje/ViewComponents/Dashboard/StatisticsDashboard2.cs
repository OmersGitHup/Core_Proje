using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
		Context c = new Context();

		public IViewComponentResult Invoke()
        {

            ViewBag.numberOfProject = c.Porfolios.Count();
            ViewBag.numberOfServices=c.Services.Count();
            ViewBag.numberOfMessages=c.Messages.Count();

            return View();
        }


    }
}
