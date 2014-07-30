namespace Controller.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Preview controller
    /// </summary>
    public class PreviewController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}