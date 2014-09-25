namespace Website
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Class to configure routes
    /// </summary>
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Application", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}