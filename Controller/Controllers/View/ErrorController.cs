namespace Controller.Controllers.View
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

    /// <summary>
    /// Error controller
    /// </summary>
    public class ErrorController : ControllerViewBase
    {
        // GET: /Error
        public ActionResult Index()
        {
            return View();
        }
    }
}