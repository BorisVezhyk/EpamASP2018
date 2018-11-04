using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Less14HomeWork_route_.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Main()
		{
			ViewBag.Message = "Hello Friend!! You are in our web site. You will find many intresting news!";
			return View();
		}

		public ActionResult Economy()
		{
			return View();
		}

		public ActionResult Politics()
		{
			return View();
		}

		public ActionResult Sport()
		{
			return View();
		}

		public ActionResult Society()
		{
			return View();
		}
	}
}