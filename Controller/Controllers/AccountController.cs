namespace Controller.Controllers
{
    using Controller.Filters;
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Responses;
    using Infrastructure.Tools;
    using Service.Account.Requests;
    using Service.Services;
    using Service.ViewModels.Account;
    using System.Web.Mvc;
    using WebMatrix.WebData;

    /// <summary>
    /// Account controller
    /// </summary>
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : ViewControllerBase
    {
        [AllowAnonymous]
        public ActionResult SetCulture(string returnUrl, string culture)
        {
            Cookies.SetCulture(HttpContext, culture);

            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Connection()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ValidateRegistration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration");
            }

            AccountService accountService = new AccountService();
            var request = new RegisterUserRequest(registrationViewModel);
            Response<Empty> response = accountService.RegisterUser(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Registration");
            }

            return RedirectToAction("Index", "Application");
        }

        [AllowAnonymous]
        public ActionResult ValidateConnection(ConnectionViewModel connectionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Connection");
            }

            AccountService accountService = new AccountService();
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