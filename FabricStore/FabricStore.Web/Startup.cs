using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FabricStore.Web.Startup))]
namespace FabricStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
