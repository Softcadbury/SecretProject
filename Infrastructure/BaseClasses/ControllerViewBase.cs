namespace Infrastructure.BaseClasses
{
    using Infrastructure.Tools;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// A baseline definition that every view controllers will inherit from
    /// </summary>
    public abstract class ControllerViewBase : Controller
    {
        /// <summary>
        /// Override ExecuteCore method to manage internationalization
        /// </summary>
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = Cookies.GetCulture(HttpContext);

            if (string.IsNullOrEmpty(cultureName) && Request.UserLanguages != null && Request.UserLanguages.Length > 0)
            {
                cultureName = Request.UserLanguages.First();
            }

            cultureName = Culture.GetImplementedCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}