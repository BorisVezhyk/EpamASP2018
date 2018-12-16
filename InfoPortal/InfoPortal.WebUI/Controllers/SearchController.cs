using System.Collections.Generic;
using System.Web.Mvc;
using Common;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
	public class SearchController : Controller
	{

		public PartialViewResult SearchMenu()
		{
			var model = new SearchAttributes();
			model.SelectList = new List<SelectListItem>
			{
				new SelectListItem {Value = ((int) SearchType.ByNamesOrArticles).ToString(), Text = "Articles"},
				new SelectListItem {Value = ((int) SearchType.ByTags).ToString(), Text = "Tags"},
				new SelectListItem {Value = ((int) SearchType.ByDate).ToString(), Text = "Date"}
			};
			return PartialView(model);
		}

		[HttpPost]
		public ActionResult ResultSearch(SearchAttributes searchParameters)
		{
			if (searchParameters.SearchQuery != null)
			{
				return RedirectToAction("ResultSearch","Main",
					new {searchQuery = searchParameters.SearchQuery, selectSearch = searchParameters.Select});
			}

			return HttpNotFound();
		}
		
	}
}