using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string admin = "admin@admin.com";
            var values = writerMessageManager.GetListReceiverMessage(admin).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();
            var values2 = writerMessageManager.GetListReceiverMessage(admin);
            ViewBag.messages = values2.Count();

            return View(values);

            
        }
    }
}
