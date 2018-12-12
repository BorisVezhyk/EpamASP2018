using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;

namespace InfoPortal.WebUI.Controllers
{
	public class NavController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;

		public NavController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		// GET: Nav
		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;
			IEnumerable<string> topCategories = _categoryRepository.Categories
				.Select(c => c.CategoryName)
				.Distinct();

			return PartialView(topCategories);
		}
	}
}