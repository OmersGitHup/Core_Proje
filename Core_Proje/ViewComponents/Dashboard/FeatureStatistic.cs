using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
	public class FeatureStatistic : ViewComponent
	{
		Context c=new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = c.Skills.Count();
			ViewBag.v2= c.Messages.Where(x=>x.Status==false).Count();
			ViewBag.v3= c.Testimonials.Count();
			ViewBag.v4=c.Experiences.Count();
			//var values = contactManager.TGetList();
			return View();
		}

	}
}
