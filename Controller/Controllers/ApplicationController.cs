namespace Controller.Controllers
{
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
            Cookies.SetCulture(HttpContext, culture);

            return RedirectToAction("Index");
        }
    }
}