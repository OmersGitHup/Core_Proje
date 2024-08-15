using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
	{
		WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
		public IActionResult Inbox()
		{
			string p;
			p = "admin@admin.com";
			var values = writerMessageManager.GetListReceiverMessage(p);
			return View(values);
		}
		public IActionResult Sent()
		{
			string p;
			p = "admin@admin.com";
			var values = writerMessageManager.GetListSenderMessage(p);
			return View(values);
		}
		public IActionResult AdminMessageDetails(int id) {
			var values = writerMessageManager.TGetByID(id);
			return View(values);
		}
		public IActionResult Delete(int id)
		{
			var values=writerMessageManager.TGetByID(id);
			writerMessageManager.TDelete(values);
			return View();
		}

		[HttpGet]
		public IActionResult AdminMessageSend(int id)
		{
			
			return View();

		}
		[HttpPost]
		public IActionResult AdminMessageSend(WriterMessage p)
		{
			p.Sender = "admin@admin.com";
			p.SenderName = "ADMIN";
			p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			Context c = new Context();
			var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			p.ReceiverName = usernamesurname;
			writerMessageManager.TAdd(p);
			return RedirectToAction("Sent");

		}
	}
}
