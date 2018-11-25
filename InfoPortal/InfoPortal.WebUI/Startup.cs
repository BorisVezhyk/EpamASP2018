using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoPortal.WebUI.Startup))]
namespace InfoPortal.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
