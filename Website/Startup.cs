[assembly: Microsoft.Owin.OwinStartup(typeof(Website.Startup))]

namespace Website
{
    using Owin;

    /// <summary>
    /// Class used at the application startup
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}