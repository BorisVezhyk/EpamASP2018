namespace InfoPortal.WebUI.Controllers
{
	using BL.Interfaces;
	using System.Web.Mvc;

	public class RandomArticlesController : Controller
	{
		private readonly IArticlesRepository articles;

		public RandomArticlesController(IArticlesRepository articles)
		{
			this.articles = articles;
		}

		// GET: RandomArticles
		public PartialViewResult RandomArticlesResult(int excludeId)
		{
			var model = this.articles.GetRandomArticles(excludeId);
			return this.PartialView(model);
		}
	}
}