﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common;
using InfoPortal.BL.Interfaces;

namespace InfoPortal.WebUI.Controllers
{
	public class AdminController : Controller
	{
		private readonly IUserRepository users;

		private readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public AdminController(IUserRepository users)
		{
			this.users = users;
		}

		// GET: Admin
		public ActionResult Index(int page = 1)
		{
			List<User> model = this.users.GetUsersForAdmin(page);

			//add pageinfo 
			return View(model);
		}

		// GET: Admin/Details/5
		public ActionResult Details(int id)
		{
			User model = this.users.GetUserById(id);
			return View(model);
		}

		// GET: Admin/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					User newUser = new User
					{
						Name = collection["Name"],
						Email = collection["Email"],
						Password = collection["Password"],
					};
					if (collection["Editor"] != null)
					{
						newUser.Roles.Add(new Role { Name = collection["Editor"] });
					}

					if (collection["Admin"] != null)
					{
						newUser.Roles.Add(new Role { Name = collection["Admin"] });
					}

					this.users.RegisterUser(newUser);
					this.logger.Info(User.Identity.Name + " created a new user. The new user has name " + newUser.Name);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Admin/Edit/5
		public ActionResult Edit(int id)
		{
			User model = this.users.GetUserById(id);

			return View(model);
		}

		// POST: Admin/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					User updateUser = new User
					{
						UserId = id,
						Name = collection["Name"],
						Password = collection["Password"],
						Email = collection["Email"]
					};
					if (collection["Editor"] != null)
					{
						updateUser.Roles.Add(new Role { Name = collection["Editor"] });
					}

					if (collection["Admin"] != null)
					{
						updateUser.Roles.Add(new Role { Name = collection["Admin"] });
					}

					this.users.UpdateUser(updateUser);
					this.logger.Info(User.Identity.Name+ " updated a user with Id="+id);
					return RedirectToAction("Index");
				}

				return this.View();

			}
			catch (Exception ex)
			{
				this.logger.Error(ex.Message);
				return View();
			}
		}

		// GET: Admin/Delete/5
		public ActionResult Delete(int id)
		{
			User model = this.users.GetUserById(id);
			return View(model);
		}

		// POST: Admin/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				this.users.DeleteUserById(id);
				this.logger.Info(User.Identity.Name + " deleted a user.The user had id=" + id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}