using Microsoft.Owin;
using Owin;
using straks_nl.Web.App_Start;

[assembly: OwinStartupAttribute(typeof(straks_nl.Web.Startup))]
namespace straks_nl.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.RegisterDependencyInjection(builder =>
            {
               
            });
        }
    }
}
