namespace InfoPortal.WebUI
{
	using System.Web.Mvc;
	using System.Web.Routing;

	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapMvcAttributeRoutes();

			#region Main/List

			routes.MapRoute(
				null,
				"",
				new
				{
					controller = "Main",
					action = "List",
					category = (string)null,
					page = 1
				});

			routes.MapRoute(
				null,
				"Page{page}",
				new
				{
					controller = "Main",
					action = "List",
					category = (string)null
				},
				new { page = @"\d+" });

			routes.MapRoute(
				null,
				"{category}",
				new { controller = "Main", action = "List", page = 1 });

			routes.MapRoute(
				null,
				"{category}/Page{page}",
				new { controller = "Main", action = "List" },
				new { page = @"\d+" });

			#endregion

			#region Article/ListOfArticles

			routes.MapRoute(
				null,
				"ListOfArticles/AllUsers",
				new
				{
					controller = "Article",
					action = "ListOfArticles",
					userName = (string)null,
					page = 1
				});

			routes.MapRoute(
				null,
				"ListOfArticles/AllUsers/Page{page}",
				new
				{
					controller = "Article",
					action = "ListOfArticles",
					userName = (string)null,
				},
				new { page = @"\d+" });

			routes.MapRoute(
				null,
				"ListOfArticles/{userName}",
				new
				{
					controller = "Article",
					action = "ListOfArticles",
					page = 1,
				});

			routes.MapRoute(
				null,
				"ListOfArticles/{userName}/Page{page}",
				new
				{
					controller = "Article",
					action = "ListOfArticles"
				},
				new { page = @"\d+" });

			#endregion

			#region main/ListArticlesOfUser 

			routes.MapRoute(
				null,
				"ListArticlesOfUser/{userName}",
				new
				{
					controller = "Main",
					action = "ListArticlesOfUser",
					page = 1
				});

			routes.MapRoute(
				null,
				"ListArticlesOfUser/{userName}/Page{page}",
				new
				{
					controller = "Main",
					action = "ListArticlesOfUser",
				},
				new { page = @"\d+" });

			#endregion

			#region main/ResultSearch

			routes.MapRoute(
				null,
				"ResultSearch/Articles/{searchQuery}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 1,
					page = 1
				});

			routes.MapRoute(
				null,
				"ResultSearch/Articles/{searchQuery}/Page{page}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 1
				},
				new { page = @"\d+" });

			routes.MapRoute(
				null,
				"ResultSearch/Tag/{searchQuery}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 2,
					page = 1
				});

			routes.MapRoute(
				null,
				"ResultSearch/Tag/{searchQuery}/Page{page}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 2
				},
				new { page = @"\d+" });

			routes.MapRoute(
				null,
				"ResultSearch/Date/{searchQuery}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 3,
					page = 1
				});

			routes.MapRoute(
				null,
				"ResultSearch/Date/{searchQuery}/Page{page}",
				new
				{
					controller = "Main",
					action = "ResultSearch",
					selectSearch = 3
				},
				new {page=@"\d+"});
			#endregion



			routes.MapRoute(null, "{controller}/{action}");

			//routes.MapRoute(
			//	null,
			//	url: "{controller}/{action}/{userName}",
			//	defaults: new
			//	{
			//		controller = "Main",
			//		action = "ListArticlesOfUser",
			//		page = 1
			//	},
			//	constraints: new { userName = @"\w+", });

			//routes.MapRoute(
			//	null,
			//	url: "{controller}/{action}/{userName}/Page{page}",
			//	defaults: new
			//	{
			//		controller = "Main",
			//		action = "ListArticlesOfUser",
			//	},
			//	constraints: new { userName = @"\w+", page = @"\d+" });

			////??
			//			routes.MapRoute(
			//				null,
			//				url: "{action}/{selectSearch}/{searchQuery}",
			//				defaults: new
			//				{
			//					controller = "Main",
			//					action = "ResultSearch",
			//					selectSearch = 1,
			//					page = 1
			//				},
			//				constraints: new { searchQuery = @"\w+", selectSearch = @"\d+" });

			//RouteForArticle

			//routes.MapRoute(
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "Main", action = "List", id = UrlParameter.Optional }
			//);
		}
	}
}