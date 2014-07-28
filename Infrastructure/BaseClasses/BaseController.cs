namespace Infrastructure.BaseClasses
{
    using System;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Tools;

    /// <summary>
    /// A baseline definition that every controller will inherit from
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Override ExecuteCore method to manage internationalization
        /// </summary>
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            HttpCookie cultureCookie = GetCultureCookie();
            string cultureName = null;

            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else if (Request.UserLanguages != null && Request.UserLanguages.Length > 0)
            {
                cultureName = Request.UserLanguages[0];
            }

            cultureName = Culture.GetImplementedCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        /// <summary>
        /// Get the culture cookie
        /// </summary>
        protected HttpCookie GetCultureCookie()
        {
            return Request.Cookies["_culture"];
        }
    }
}