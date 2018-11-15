using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpamASPCourse.Models;

namespace EpamASPCourse.Controllers
{
    public class TableController : Controller
    {

		UserContext db=new UserContext();
        // GET: Table
        public ActionResult Index()
        {

            return View();
        }

	    public ActionResult ShowTable(int numbersOfRows = 5)
	    {
		   
		    var userList = db.Users.ToList();
		    return PartialView("_Table", userList);
	    }
    }
}