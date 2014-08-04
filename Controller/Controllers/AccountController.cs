namespace Controller.Controllers
{
    using Controller.ViewModels.Account;
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;

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

        public ActionResult ValidateRegistration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Registration");
            }

            return RedirectToAction("Index", "Application");
        }

        public ActionResult ValidateConnection(ConnectionViewModel connectionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Connection");
            }

            return RedirectToAction("Index", "Application");
        }
    }
}