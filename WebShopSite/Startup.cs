using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopSite.Startup))]
namespace WebShopSite
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
