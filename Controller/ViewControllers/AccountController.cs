namespace Controller.ViewControllers
{
    using Service.ViewModels.Account;
    using Infrastructure.BaseClasses;
    using Infrastructure.Tools;
    using Service.Services;
    using System.Web.Mvc;

    /// <summary>
    /// Account controller
    /// </summary>
    public class AccountController : ViewControllerBase
    {
        private readonly AccountService accountService;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountController()
        {
            accountService = new AccountService();
        }

        public ActionResult SetCulture(string returnUrl, string culture)
        {
            Cookies.SetCulture(HttpContext, culture);

            return Redirect(returnUrl);
        }

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