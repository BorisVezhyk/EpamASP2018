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
	    private const int PAGE_SIZE = 10;
	    private int countPage = 0;
		
		UserContext db=new UserContext();
        // GET: Table
        public ActionResult Index(string nameUser, int page=1)
        {
	        UserListViewModel model = new UserListViewModel
	        {
		        Users = db.Users
			        .Where(u=>nameUser==null || u.Name==nameUser)
			        .OrderBy(u => u.UserId)
			        .Skip((page - 1) * PAGE_SIZE)
			        .Take(PAGE_SIZE),
		        PagingInfo = new PagingInfo()
		        {
			        CurrentPage = page,
			        ItemsPerPage = PAGE_SIZE,
			        TotalItems = db.Users.Count()
		        },
				NameUser = nameUser
	        };
			return View(model);
        }

	    [HttpPost]
	    public ActionResult Index(UserListViewModel viewModel)
	    {
		    return Index(viewModel.NameUser);
	    }
    }
}