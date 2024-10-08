﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutManager.TGetByID(3);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {

            _aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");

        }

        public IActionResult About()
        {
            return View();
        }
    }
}
