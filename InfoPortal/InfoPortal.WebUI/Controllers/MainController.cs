using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;

namespace InfoPortal.WebUI.Controllers
{
	public class MainController : Controller
	{
		IArticlesRepository _articles=new ArticleRepository();

		public ActionResult Index()
		{
			
			
			return View(_articles.Articles.Take(6));
		}
		
	}
}