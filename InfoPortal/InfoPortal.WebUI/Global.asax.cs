using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;
using InfoPortal.WebUI.Controllers;

namespace InfoPortal.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
	        log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
		}
	  
    }
	
}
