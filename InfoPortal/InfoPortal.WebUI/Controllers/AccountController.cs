namespace InfoPortal.WebUI.Controllers
{
	using BL.Interfaces;
	using Common;
	using Models;
	using System.Web.Mvc;
	using System.Web.Security;

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
			if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
			{
				returnUrl = Server.UrlDecode(Request.UrlReferrer.PathAndQuery);
			}

			if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
			{
				ViewBag.ReturnURL = returnUrl;
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel login, string returnUrl)
		{
			string decodedUrl = "";

			if (!string.IsNullOrEmpty(returnUrl))
			{
				decodedUrl = Server.UrlDecode(returnUrl);
			}

			if (ModelState.IsValid)
			{
				User user = userRepository.GetUserByLogin(login.Name, login.Password);

				if (user != null)
				{
					FormsAuthentication.SetAuthCookie(login.Name, login.RememberMe);
					if (Url.IsLocalUrl(decodedUrl))
					{
						return Redirect(decodedUrl);
					}
					else
					{
						return RedirectToAction("List", "Main");
					}
				}
				else
				{
					ModelState.AddModelError("", "User with this Name and Password doesn't exist");
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
				if (userRepository.CheckUserExist(newUser.Email, newUser.Name) >= 1)
				{
					ModelState.AddModelError("", "User with this Name or Email already exists");
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
					if (userLogin != null)
					{
						FormsAuthentication.SetAuthCookie(userLogin.Name, true);
						return RedirectToAction("List", "Main");
					}
				}
			}

			return View(newUser);
		}

		public ActionResult UserProfile(string userName)
		{
			User model = this.userRepository.GetUserByName(userName);
			return this.View(model);
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("List", "Main");
		}
	}
}