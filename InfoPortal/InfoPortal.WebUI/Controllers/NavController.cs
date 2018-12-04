using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
    public class NavController : Controller
    {
	    private const int PAGE_SIZE = 6;

		private readonly ICategoryRepository _categoryRepository;

	    private readonly IArticlesRepository _articlesRepository;

	    public NavController(ICategoryRepository categoryRepository,IArticlesRepository articlesRepository)
	    {
		    _articlesRepository = articlesRepository;
		    _categoryRepository = categoryRepository;
	    }
        
	    // GET: Nav
        public PartialViewResult Menu(string category=null)
        {
	        ViewBag.SelectedCategory = category;
	        IEnumerable<string> topCategories = _categoryRepository.Categories
		        .Select(c => c.CategoryName)
		        .Distinct();

            return PartialView(topCategories);
        }

	   


	    [HttpPost]
	    public ActionResult ResultSearchByDateTime()
	    {
		    //ArticlesListViewModel model = new ArticlesListViewModel
		    //{
			   // Articles = _articlesRepository.Articles
				  //  .Where(a => date.ToString("d") == a.Date.ToString("d"))
				  //  .OrderBy(a => a.ArticleID)
				  //  .Skip((page - 1) * PAGE_SIZE)
				  //  .Take(PAGE_SIZE),
			   // PageInfo = new PageInfo
			   // {
				  //  CurrentPage = page,
				  //  ItemsPerPage = PAGE_SIZE,
				  //  TotalItems = _articlesRepository.Articles
					 //   .Count(a => a.Date.ToString("d") == date.ToString("d"))
			   // }

		    //};

		    return View();
	    }
    }
}