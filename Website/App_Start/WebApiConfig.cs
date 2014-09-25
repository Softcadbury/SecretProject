namespace Website
{
    using System.Web.Http;

    /// <summary>
    /// Class to configure the web api
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}