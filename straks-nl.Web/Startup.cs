using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(straks_nl.Web.Startup))]
namespace straks_nl.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
