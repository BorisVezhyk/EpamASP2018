using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
		[HttpGet]
        public PartialViewResult SearchMenu()
        {
			var model=new SearchAttributes();
	        model.SelectList = new List<SelectListItem>
	        {
		        new SelectListItem {Value = "1", Text = "Articles"},
		        new SelectListItem {Value = "2", Text = "Tags"},
		        new SelectListItem {Value = "3", Text = "Date"}
	        };
            return PartialView(model);
        }

	    [HttpPost]
	    public ActionResult ResultSearch(SearchAttributes search)
	    {
		    if (search!=null)
		    {
			    string res = "select= " + search.Select.ToString() + " date= " + search.Date.ToString("d");
			    return View(res);
		    }

		    return HttpNotFound();
	    }
    }
}