﻿namespace Website
{
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Repository.Contexts;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.EnsureInitialized();

            // Database initialization
            Database.SetInitializer(new CreateDatabaseIfNotExists<SecretProjectContext>());
            Database.SetInitializer(new SecretProjectInitializer());

            using (var context = new SecretProjectContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}