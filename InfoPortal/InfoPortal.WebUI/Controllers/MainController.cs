using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class MainController : Controller
	{

		private readonly IArticlesRepository _articles;

		public  int PageSize = 6;

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
					.OrderBy(a => a.ArticleID)
					.Skip((page - 1) * PageSize)
					.Take(PageSize),
				PageInfo = new PageInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
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