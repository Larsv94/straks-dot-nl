namespace straks_nl.Data.Migrations
{
    using straks_nl.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<straks_nl.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "straks_nl.Data.ApplicationDbContext";
        }

        protected override void Seed(straks_nl.Data.ApplicationDbContext context)
        {
            var isDev = ConfigurationManager.AppSettings["Environment"].Equals("dev");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (isDev && !System.Diagnostics.Debugger.IsAttached)
            {
                /*Uncomment to debug Seed function*/
                //System.Diagnostics.Debugger.Launch();
            }

            if (isDev)
            {
                SeedTestData(context);
            }
        }

        private void SeedTestData(ApplicationDbContext context)
        {
            //Generate TestData
        }
    }
}
