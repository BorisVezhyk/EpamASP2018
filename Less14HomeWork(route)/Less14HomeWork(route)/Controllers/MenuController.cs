using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Less14HomeWork_route_.Models;

namespace Less14HomeWork_route_.Controllers
{
    public class MenuController : Controller
    {
		Category _cat=new Category();
        // GET: Category
        public PartialViewResult Nav()
        {
	        return PartialView(_cat);
        }
    }
}