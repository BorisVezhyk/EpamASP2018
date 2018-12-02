using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;

namespace InfoPortal.WebUI.Controllers
{
    public class NavController : Controller
    {
	    private readonly IArticlesRepository _repository;

	    public NavController(IArticlesRepository repository)
	    {
		    _repository = repository;
	    }
        // GET: Nav
        public PartialViewResult Menu(string category=null)
        {
	        ViewBag.SelectedCategory = category;
	        IEnumerable<string> topCategories = _repository.Articles
		        .Select(x => x.Category)
		        .Distinct();

            return PartialView(topCategories);
        }
    }
}