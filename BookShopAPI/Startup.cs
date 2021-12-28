using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShopAPI.Startup))]
namespace BookShopAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
