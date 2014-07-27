namespace Infrastructure.BaseClasses
{
    using Infrastructure.Tools;
    using System;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// A baseline definition that every controller will inherit from
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Override ExecuteCore method to manage internationalization
        /// </summary>
        protected override void ExecuteCore()
        {
            HttpCookie cultureCookie = Request.Cookies["_culture"];
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

            base.ExecuteCore();
        }
    }
}