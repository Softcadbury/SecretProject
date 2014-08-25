namespace Controller.Controllers.View
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : ControllerViewBase
    {
        // GET: /Home
        public ActionResult Index()
        {
            return View();
        }
    }
}