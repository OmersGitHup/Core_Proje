using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager _skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
			ViewBag.v1 = "Skills";
			ViewBag.v2 = "Index";
			ViewBag.v3 = "List";
			var values = _skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Skills";
			ViewBag.v2 = "AddSkill";
			ViewBag.v3 = "Add";
			return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            _skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var values= _skillManager.TGetByID(id);
            _skillManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Skills";
            ViewBag.v2 = "Update";
            ViewBag.v3 = "Skill";
            var values = _skillManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
           
            _skillManager.TUpdate(skill);
            return RedirectToAction("Index");

        }
    }
}
