using System.Text.RegularExpressions;

namespace InfoPortal.WebUI.Controllers
{
	using Common;
	using Models;
	using System.Collections.Generic;
	using System.Web.Mvc;

	public class SearchController : Controller
	{
		public PartialViewResult SearchMenu()
		{
			var model = new SearchAttributes();
			model.SelectList = new List<SelectListItem>
			{
				new SelectListItem { Value = ((int)SearchType.ByNamesOrArticles).ToString(), Text = "Articles" },
				new SelectListItem { Value = ((int)SearchType.ByTags).ToString(), Text = "Tags" },
				new SelectListItem { Value = ((int)SearchType.ByDate).ToString(), Text = "Date" }
			};
			return PartialView(model);
		}

		[HttpPost]
		public ActionResult ResultSearch(SearchAttributes searchParameters)
		{

			string strWithoutSpaces = Regex.Replace(searchParameters.SearchQuery, @"^\s+", "");
			strWithoutSpaces = Regex.Replace(strWithoutSpaces, @"\s+$", "");

			if (searchParameters.SearchQuery != null)
			{
				return RedirectToAction(
					"ResultSearch",
					"Main",
					new { searchQuery = strWithoutSpaces, selectSearch = searchParameters.Select });
			}

			return HttpNotFound();
		}
	}
}