using System.Web.Mvc;
using System.Web.Security;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserRepository userRepository;

		public AccountController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{

			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel login)
		{
			if (ModelState.IsValid)
			{
				User user = userRepository.GetUserByLogin(login.Name, login.Password);

				if (user!=null)
				{
					FormsAuthentication.SetAuthCookie(login.Name, login.RememberMe);
					return RedirectToAction("List", "Main");
				}
				else
				{
					ModelState.AddModelError("","User with this Name and Password doesn't exist");
				}
			}

			return View(login);
		}


		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterUser newUser)
		{
			if (ModelState.IsValid)
			{
				if (userRepository.CheckUserExist(newUser.Email, newUser.Name) == 1)
				{
					ModelState.AddModelError("","User with this Name or Email already exist");
				}
				else
				{
					User userForSave = new User
					{
						Name = newUser.Name,
						Email = newUser.Email,
						Password = newUser.Password
					};
					userRepository.RegisterUser(userForSave);

					User userLogin = userRepository.GetUserByLogin(newUser.Name, newUser.Password);
					if (userLogin!=null)
					{
						//ClaimsIdentity ident=
						FormsAuthentication.SetAuthCookie(userLogin.Name, true);
						return RedirectToAction("List", "Main");
					}
				}
			}

			return View(newUser);
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("List", "Main");
		}
	}
}