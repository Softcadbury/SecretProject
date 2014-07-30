namespace Controller.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Account controller
    /// </summary>
    public class AccountController : BaseController
    {
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Connection()
        {
            return View();
        }

        public ActionResult ValidateRegistration()
        {
            return RedirectToAction("Index", "Application");
        }

        public ActionResult ValidateConnection()
        {
            return RedirectToAction("Index", "Application");
        }
    }
}