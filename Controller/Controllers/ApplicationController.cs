namespace Controller.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;
    using Infrastructure.Tools;

    /// <summary>
    /// Application controller
    /// </summary>
    public class ApplicationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeContent()
        {
            return PartialView("Content/_Home");
        }

        public ActionResult AccountContent()
        {
            return PartialView("Content/_Account");
        }

        public ActionResult SetCulture(string culture)
        {
            culture = Culture.GetImplementedCulture(culture);

            HttpCookie cultureCookie = GetCultureCookie();

            if (cultureCookie != null)
            {
                cultureCookie.Value = culture;
            }
            else
            {
                cultureCookie = new HttpCookie("_culture")
                                {
                                    Value = culture,
                                    Expires = DateTime.Now.AddYears(1)
                                };
            }

            Response.Cookies.Add(cultureCookie);

            return RedirectToAction("Index");
        }
    }
}