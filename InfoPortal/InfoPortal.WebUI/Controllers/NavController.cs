using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;

namespace InfoPortal.WebUI.Controllers
{
    public class NavController : Controller
    {
		ITagsRepository _tag=new TagsRepository();

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