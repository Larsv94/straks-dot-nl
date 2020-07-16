using Autofac;
using Microsoft.Owin;
using Owin;
using straks_nl.Data;
using straks_nl.Web.App_Start;
using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;

[assembly: OwinStartupAttribute(typeof(straks_nl.Web.Startup))]
namespace straks_nl.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            var db = ApplicationDbContext.Create();
            app.RegisterDependencyInjection(builder =>
            {
                builder.Register(ctx => db).InstancePerRequest();
            });
            ConfigureAuth(app,db);
           
        }
    }
}
