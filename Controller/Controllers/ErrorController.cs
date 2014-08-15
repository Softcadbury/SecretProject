namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Error controller
    /// </summary>
    public class ErrorController : ViewControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}