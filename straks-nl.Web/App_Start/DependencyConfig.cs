using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Ajax.Utilities;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace straks_nl.Web.App_Start
{
    public static class DependencyConfig
    {
        public static void RegisterDependencyInjection(this IAppBuilder app, Action<ContainerBuilder> registerDependencies)
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            registerDependencies(builder);
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        public static void AddTransient<Dependency, Interface>(this ContainerBuilder builder)
        {
            builder.RegisterType<Dependency>().As<Interface>();
        }

        public static void AddScoped<Dependency, Interface>(this ContainerBuilder builder)
        {
            builder.RegisterType<Dependency>().As<Interface>().InstancePerRequest();
        }

        public static void AddSingleton<Dependency, Interface>(this ContainerBuilder builder)
        {
            builder.RegisterType<Dependency>().As<Interface>().SingleInstance();
        }
    }
}