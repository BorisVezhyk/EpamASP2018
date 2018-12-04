using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class MainController : Controller
	{
		readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IArticlesRepository _articles;

		private const  int PAGE_SIZE = 6;

		public MainController(IArticlesRepository res)
		{
			_articles = res;
		}

		public ActionResult List(string category, int page=1)
		{
			ArticlesListViewModel model = new ArticlesListViewModel
			{
				Articles = _articles.Articles
					.Where(a=>category==null||a.Category==category)
					.OrderByDescending(a => a.Date)
					.Skip((page - 1) * PAGE_SIZE)
					.Take(PAGE_SIZE),
				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PAGE_SIZE,
					TotalItems = category==null?
						_articles.Articles.Count():
						_articles.Articles.Count(a => a.Category==category)
				},
				CurrentCategory = category
			};

			return View(model);
		}
		
	}
}