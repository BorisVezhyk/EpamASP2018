using System.Web;
using System.Web.Mvc;

namespace Less14HomeWork_route_
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
