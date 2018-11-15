using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpamASPCourse.Models;

namespace EpamASPCourse.Controllers
{
    public class UserController : Controller
    {
	    private UserContext db = new UserContext();

        // GET: User
	    [HttpGet]
        public ActionResult UpdateUser(int id=0)
	    {
		    var upUser = db.Users.FirstOrDefault(u => u.UserId == id);

	        if (upUser!=null)
	        {
		        ViewBag.NeedUpdated = true;

				return View(upUser);
			}
	        else
	        {
		        ViewBag.NeedUpdated = false;
				return View();
	        }
        }

	    [HttpGet]
	    public ActionResult AddNewUser()
	    {
			return RedirectToAction("UpdateUser");
	    }

		[HttpPost]
	    public ActionResult UpdateUser(User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index", "Table");
			}

			return RedirectToAction("Index", "Table");
		}

		[HttpPost]
	    public ActionResult AddNewUser(User user)
	    {

		    if (ModelState.IsValid)
		    {
			    db.Users.Add(user);
				db.SaveChanges();
				return RedirectToAction("Index", "Table");
		    }

		    return RedirectToAction("UpdateUser");
		}

	    public ActionResult RemoveUser(int id = 0)
	    {
		    var user = db.Users.Find(id);
		    if (user!=null)
		    {
			    db.Users.Remove(user);
			    db.SaveChanges();
		    }
		    return RedirectToAction("Index", "Table");
	    }
	}
}