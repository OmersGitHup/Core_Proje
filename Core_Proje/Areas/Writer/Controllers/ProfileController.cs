﻿using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Route("Writer/[controller]/[action]")]

	public class ProfileController : Controller

	{
		private readonly UserManager<WriterUser> _userManager;

		public ProfileController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel model = new UserEditViewModel();
			model.Name = values.Name;
			model.Surname=values.Surname;
			
			model.PictureURL=values.ImageURL;
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (userEditViewModel.Picture != null) 
			{
				var resource = Directory.GetCurrentDirectory();
				var extension=Path.GetExtension(userEditViewModel.Picture.FileName);
				var imagename=Guid.NewGuid()+extension;
				var savelocation = resource + "/wwwroot/userimage/" + imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await userEditViewModel.Picture.CopyToAsync(stream);
				user.ImageURL=imagename;
			}
			user.Name=userEditViewModel.Name;
			user.Surname=userEditViewModel.Surname;
			if (userEditViewModel.PasswordConfirm == userEditViewModel.Password)
			{
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
			}
			else
			{
				return View();
			}
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}
			return View();
		}
	}
}
