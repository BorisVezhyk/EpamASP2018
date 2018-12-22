namespace InfoPortal.WebUI.Controllers
{
	using BL.Interfaces;
	using Models;
	using System.Web.Mvc;

	public class MainController : Controller
	{
		readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IArticlesRepository articles;

		private const int PageSize = 6;

		public MainController(IArticlesRepository res)
		{
			articles = res;
		}

		public ActionResult List(string category, int page = 1)
		{
			ArticlesListViewModel model = new ArticlesListViewModel
			{
				Articles = articles.GetArticlesForMainPage(PageSize, category, page),

				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = articles.GetCountArtiles(category)
				},
				CurrentCategory = category
			};

			return View(model);
		}

		public ActionResult ResultSearch(string searchQuery, int selectSearch, int page = 1)
		{
			ResultSearchArticlesViewModel model = new ResultSearchArticlesViewModel
			{
				Articles = articles.GetResultSearch(searchQuery, selectSearch, PageSize, page),
				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = articles.GetCountArticlesSearchResult(selectSearch, searchQuery)
				},
				SearchQuery = searchQuery,
				SelectSearch = selectSearch
			};

			return View(model);
		}
	}
}