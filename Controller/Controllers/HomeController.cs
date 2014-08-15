namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : ViewControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}