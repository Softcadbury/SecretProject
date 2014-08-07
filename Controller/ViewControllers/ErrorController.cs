namespace Controller.ViewControllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

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