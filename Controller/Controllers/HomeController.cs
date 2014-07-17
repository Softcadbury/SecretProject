namespace Controller.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
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