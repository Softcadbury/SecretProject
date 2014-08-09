namespace Controller.ViewControllers
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Responses;
    using Infrastructure.Tools;
    using Service.Account.Requests;
    using Service.Services;
    using Service.ViewModels.Account;
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
                return View("Registration");
            }

            var request = new RegisterUserRequest(registrationViewModel);
            Response<Empty> response = accountService.RegisterUser(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Registration");
            }

            return RedirectToAction("Index", "Application");
        }

        public ActionResult ValidateConnection(ConnectionViewModel connectionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Connection");
            }

            var request = new ConnectUserRequest(connectionViewModel);
            Response<Empty> response = accountService.ConnectUser(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Connection");
            }

            return RedirectToAction("Index", "Application");
        }
    }
}