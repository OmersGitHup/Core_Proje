﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ErrorPagesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Error404()
        {
            return View();
        }
    }
}
