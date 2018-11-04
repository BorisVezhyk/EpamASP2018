using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Less14HomeWork_route_
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				null,
				"Registration",
				new {controller = "Register", action = "Registration"});

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/",
				defaults: new { controller = "Home", action = "Main"}
			);
		}
	}
}
