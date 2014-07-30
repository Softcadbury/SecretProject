namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Error controller
    /// </summary>
    public class ErrorController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}