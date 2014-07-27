namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseController
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
    }
}