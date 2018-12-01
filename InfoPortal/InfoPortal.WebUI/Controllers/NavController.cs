using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InfoPortal.BL.Abstract;

namespace InfoPortal.WebUI.Controllers
{
    public class NavController : Controller
    {
	    private readonly ITagsRepository _tag;

	    public NavController(ITagsRepository repository)
	    {
		    _tag = repository;
	    }
        // GET: Nav
        public PartialViewResult Menu()
        {
	        IEnumerable<string> topCategories = _tag.Tags
		        .Select(x => x.TagName)
		        .Distinct()
		        .OrderBy(x => x);

            return PartialView(topCategories);
        }
    }
}