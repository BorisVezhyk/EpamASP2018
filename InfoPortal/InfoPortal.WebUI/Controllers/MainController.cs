using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class MainController : Controller
	{
		readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IArticlesRepository _articles;

		private const int PAGE_SIZE = 6;

		public MainController(IArticlesRepository res)
		{
			_articles = res;
		}

		public ActionResult List(string category, int page = 1)
		{
			ArticlesListViewModel model = new ArticlesListViewModel
			{
				Articles = _articles.GetArticlesForMainPage(PAGE_SIZE, category, page),

				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PAGE_SIZE,
					TotalItems =_articles.GetCountArtiles(category)
				},
				CurrentCategory = category
			};

			return View(model);
		}
	}
}