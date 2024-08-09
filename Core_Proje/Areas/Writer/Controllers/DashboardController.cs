using Core_Proje.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
	[Route("Writer/[controller]/[action]")]
	public class DashboardController : Controller
	{
		
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;


            //Weather api
            string api = "66798b0838fb82e1c974a8aa3ec802bd";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //statistics
            Context c=new Context();
            ViewBag.totalMessages = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.announcementTotal= c.Announcements.Count();
            ViewBag.totalUsers = c.Users.Count();
            ViewBag.totalAbilities = c.Skills.Count();
            return View();
		}
	}
}
