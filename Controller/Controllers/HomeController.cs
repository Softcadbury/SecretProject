namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Gets The home index
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}