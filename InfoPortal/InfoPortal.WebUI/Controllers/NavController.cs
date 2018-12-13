using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Interfaces;

namespace InfoPortal.WebUI.Controllers
{
	public class NavController : Controller
	{
		private readonly ICategoryRepository categoryRepository;

		public NavController(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		// GET: Nav
		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;
			IEnumerable<string> topCategories = categoryRepository.Categories
				.Select(c => c.CategoryName)
				.Distinct();

			return PartialView(topCategories);
		}
	}
}