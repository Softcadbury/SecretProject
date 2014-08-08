namespace Controller.ViewControllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseViewController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}