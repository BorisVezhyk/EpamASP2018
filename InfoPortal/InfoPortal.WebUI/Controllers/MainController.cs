using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class MainController : Controller
	{
		readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		private readonly IArticlesRepository _articles;

		public  int PageSize = 6;

		public MainController(IArticlesRepository res)
		{
			_articles = res;
		}

		public ActionResult Index(int page=1)
		{

			ArticlesListViewModel model = new ArticlesListViewModel
			{
				Articles = _articles.Articles
					.OrderBy(a => a.ArticleID)
					.Skip((page - 1) * PageSize)
					.Take(PageSize),
				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = _articles.Articles.Count()
				}
			};

			return View(model);
		}
		
	}
}