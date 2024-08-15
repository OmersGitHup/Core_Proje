using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
	public class MessageList:ViewComponent
	{
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		public IViewComponentResult Invoke()
		{
			var values = messageManager.TGetList()
						  .OrderByDescending(x => x.Date)
						  .Take(5).ToList();

			return View(values);
		}

	}
}
